namespace Asp.NET_Core_MVC.Logger
{
    public class SmsLogger : ILogger
    {
        public void Write()
        {
            Console.WriteLine("Sms gönderildi.");
        }
    }
}
