using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContent,config) =>
            {
                var env = hostingContent.HostingEnvironment;

                config.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsetting.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
