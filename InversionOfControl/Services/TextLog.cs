using InversionOfControl.Services.Interfaces;

namespace InversionOfControl.Services
{
    public class TextLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("Text dosyasına loglama işlemi gerçekleştirildi.");

        }
    }
}
