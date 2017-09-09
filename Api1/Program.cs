using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Api1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Title = "API 1";

			var host = new WebHostBuilder()
					.UseKestrel()
					.UseUrls("http://localhost:5001")
					.UseContentRoot(Directory.GetCurrentDirectory())
					.UseIISIntegration()
					.UseStartup<Startup>()
					.UseApplicationInsights()
					.Build();

			host.Run();
		}
	}
}