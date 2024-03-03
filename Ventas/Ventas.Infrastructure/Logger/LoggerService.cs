using Microsoft.Extensions.Logging;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Logger
{
    public class LoggerService<T> : ILoggerService<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger){
            _logger = logger;
        }


        public void LogCritical(string message, Exception exception)
        {
            _logger.LogCritical(message, exception, "Hola");
        }

        public void LogError(string message, Exception exception)
        {
            _logger?.LogError(message, exception);
        }

        public void LogInformation(string message, object obj)
        {
            _logger.LogInformation(message, obj);
        }

        public void LogWarning(string message, object obj)
        {
            _logger.LogWarning(message, obj);
        }
    }
}
