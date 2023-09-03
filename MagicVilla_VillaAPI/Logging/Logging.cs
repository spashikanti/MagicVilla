using MagicVilla_VillaAPI.Controllers;

namespace MagicVilla_VillaAPI.Logging
{
    public class Logging : ILogging
    {
        private readonly ILogger<Logging> _logger;

        public Logging(ILogger<Logging> logger)
        {
            _logger = logger;
        }

        public void Log(string message, string type)
        {
            if(type == "error")
            {
                _logger.LogError("ERROR - " + message);
                Console.WriteLine("ERROR - " + message);
            }
            else
            {
                _logger.LogWarning(message);
                Console.WriteLine(message);
            }
        }
    }
}
