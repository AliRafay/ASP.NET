using System.Diagnostics;

namespace Services
{
    class CloudMailService : IMailService
    {
        private string mailTo = "anonymous@mycompany.com";
        private string mailFrom = "admin@mycompany.com";

        public void Send(string Subject, string Message)
        {
            Debug.WriteLine($"Mail from {mailFrom} To {mailTo} by Cloud Mail Server");
            Debug.WriteLine($"Subject: {Subject}");
            Debug.WriteLine($"Message: {Message}");
        }
    }
}
