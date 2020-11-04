namespace Services
{
    public interface IMailService
    {
        void Send(string Subject, string Message);
    }
}