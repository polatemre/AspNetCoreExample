namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public class SmsLogger : ILogger
    {
        public void Write()
        {
            Console.WriteLine("Sms gönderildi.");
        }
    }
}
