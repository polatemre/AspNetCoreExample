namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public interface ILogger
    {
        void Write()
        {
            Console.WriteLine("Merhaba");
        }
    }
}
