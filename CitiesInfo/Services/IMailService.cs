namespace Services
{
    interface IMailService
    {
        void Send(string Subject, string Message);
    }
}