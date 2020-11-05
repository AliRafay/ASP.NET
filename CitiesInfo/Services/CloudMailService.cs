using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace Services
{
    public class CloudMailService : IMailService
    {
        private readonly IConfiguration config;
        public CloudMailService(IConfiguration c)
        //We don't need to link appsettings to IConfiguration
        //CreateDefaultBrowser already does this:  //https://github.com/aspnet/MetaPackages/blob/master/src/Microsoft.AspNetCore/WebHost.cs
        //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        {
            config = c ??
                throw new ArgumentNullException(nameof(c));
        }
        //private string mailTo = "anonymous@mycompany.com";
        //private string mailFrom = "admin@mycompany.com";

        public void Send(string Subject, string Message)
        {
            Debug.WriteLine($"Mail from {config["mailSettings:mailFromAddress"]} To {config["mailSettings:mailToAddress"]} by Cloud Mail Server");
            Debug.WriteLine($"Subject: {Subject}");
            Debug.WriteLine($"Message: {Message}");
        }
    }
}
