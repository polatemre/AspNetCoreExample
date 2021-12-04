namespace Asp.NET_Core_Empty_to_MVC.Logger
{
    public class LoggerManager : ILogger
    {
        private readonly ILogger _logger;

        public LoggerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Write()
        {
            _logger.Write();
        }
    }
}
