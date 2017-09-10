using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
	internal class Program
	{
		public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

		private static async Task MainAsync()
		{
			Console.Title = "Client";

			await DoAllTheStuffAsync();
			Console.ReadLine();
		}

		private static async Task DoAllTheStuffAsync()
		{
			var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

			// request token

			//var tokenResponse = await UseClientCredidentials(disco);
			var tokenResponse = await UseResourceOwner(disco);

			if (tokenResponse.IsError)
			{
				Console.WriteLine(tokenResponse.Error);
				return;
			}

			Console.WriteLine(tokenResponse.Json);

			// call api
			var client = new HttpClient();
			client.SetBearerToken(tokenResponse.AccessToken);

			var response = await client.GetAsync("http://localhost:5001/identity");
			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine(response.StatusCode);
			}
			else
			{
				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine(JArray.Parse(content));
			}
		}

		private static async Task<TokenResponse> UseClientCredidentials(DiscoveryResponse disco)
		{
			var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
			var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
			return tokenResponse;
		}

		private static async Task<TokenResponse> UseResourceOwner(DiscoveryResponse disco)
		{
			var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
			var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");
			return tokenResponse;
		}
	}
}