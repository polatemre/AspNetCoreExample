namespace Asp.NET_Core_MVC.Logger
{
    public abstract class ILogger
    {
        void Write()
        {
            Console.WriteLine("Merhaba");
        }
    }
}
