namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public class DatabaseLogger : ILogger
    {
        public void Write()
        {
            Console.WriteLine("Database yazıldı.");
        }
    }
}
