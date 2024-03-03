

namespace Ventas.Infrastructure.Interfaces
{
    public interface ILoggerService<TController> where TController: class
    {
        void LogInformation(string message, object obj);
        void LogWarning(string message, object obj);
        void LogError(string message, Exception exception);
        void LogCritical(string message, Exception exception);
    }
}
