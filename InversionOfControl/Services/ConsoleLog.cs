using InversionOfControl.Services.Interfaces;

namespace InversionOfControl.Services
{
    public class ConsoleLog : ILog
    {
        public ConsoleLog(int a)
        {

        }
        public void Log()
        {
            Console.WriteLine("Console'a loglama işlemi gerçekleştirildi.");
        }
    }
}
