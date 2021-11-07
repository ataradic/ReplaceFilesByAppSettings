using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace  ReplaceString

{
    class Program
    {
        public static List<Replace> replacements = new List<Replace>();
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            // Application code should start here.
            
            foreach (var item in replacements)
            {
                //To dry mode call this function with true
                //To wet mode call this function with false
                Console.WriteLine(item.replaceAll(true));
                Console.WriteLine(item.replaceAll(false));
            }  
            //await host.RunAsync();
        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    configuration
                       .AddJsonFile("appsettings.json", true, true);
                    IConfigurationRoot configurationRoot = configuration.Build();
                    configurationRoot.GetSection("Replacements")
                                     .Bind(replacements);
                });
        
    }
    
}