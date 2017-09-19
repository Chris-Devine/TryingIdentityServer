using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace IdentityServerBasic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer";

            var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls("http://localhost:5000")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseApplicationInsights()
                    .Build();

            host.Run();
        }
    }
}