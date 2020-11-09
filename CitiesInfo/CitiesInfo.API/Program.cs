using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection;

namespace CitiesInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    try
            //    {
            //        var Context = scope.ServiceProvider.GetService<CityInfoContext>();

            //        //for demo purposes only, this is how we create a new database with initial migration
            //        Context.Database.EnsureDeleted();
            //        Context.Database.Migrate();
            //    }
            //    catch
            //    {
            //        Debug.WriteLine("Something happened while migrating database");
            //    }
            //}
            ////run the web app
            //host.Run();
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
