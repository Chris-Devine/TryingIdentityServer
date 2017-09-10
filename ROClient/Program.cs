using System;
using System.Threading.Tasks;

namespace ROClient
{
	internal class Program
	{
		public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

		private static async Task MainAsync()
		{
			Console.Title = "Resource Owner Client";

			await DoAllTheStuffAsync();
			Console.ReadLine();
		}

		private static Task DoAllTheStuffAsync()
		{
			throw new NotImplementedException();
		}
	}
}