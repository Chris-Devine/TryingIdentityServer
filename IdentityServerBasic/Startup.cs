using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentityServerBasic
{
	// If you run and goto http://localhost:5000/.well-known/openid-configuration you will see the discovery document
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// Add identity server and temp signing cert
			// We also tell it were to find APIs and clients configs
			services.AddIdentityServer()
				.AddTemporarySigningCredential()
				.AddInMemoryApiResources(Config.GetApiResources())
				.AddInMemoryClients(Config.GetClients())
				.AddTestUsers(Config.GetUsers());

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(LogLevel.Debug);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentityServer();

			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	}
}