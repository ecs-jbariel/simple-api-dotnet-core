using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SimpleApi
{
    public class Program
    {

        static IWebHost WebHost;

        public static void Main(string[] args)
        {

            Console.WriteLine("Starting SimpleApi...");

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();

            Console.WriteLine("Config built...");

            WebHost = new WebHostBuilder()
                .UseConfiguration(config) 
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            
            Console.WriteLine("WebHost built...");

            WebHost.Run();
            
        }
    }
}
