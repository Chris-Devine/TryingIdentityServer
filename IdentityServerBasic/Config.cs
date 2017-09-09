using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerBasic
{
	public class Config
	{

		// Here is were we define are API's
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{ 
				new ApiResource("api1", "My API")
			};
		}

		// Here we define are clients that have access to the API's (clients are things like UI's, they are not users)
		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{ 
				new Client
				{
						ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
						{
								new Secret("secret".Sha256())
						},

            // scopes that client has access to
            AllowedScopes = { "api1" }
				}
			};
		}

	}
}
