using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CitiesInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    //If you want to add more configurations files along with appsettings
                    //(But not prefered)

                    //webBuilder.ConfigureAppConfiguration(config =>
                    //{
                    //    config.AddJsonFile("mySettings.json", optional: true, reloadOnChange: true);
                    //});
                });
    }
}
