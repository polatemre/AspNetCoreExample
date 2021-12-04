namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public class FileLogger : ILogger
    {
        public void Write()
        {
            Console.WriteLine("Dosyaya yazıldı.");
        }
    }
}
