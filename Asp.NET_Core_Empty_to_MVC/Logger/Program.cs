namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public class Program
    {
        public void Main()
        {
            LoggerManager loggerManager = new(new SmsLogger());
            ILogger logger = new FileLogger();
            loggerManager.Write();
        }
    }
}
