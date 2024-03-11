

namespace Ventas.Infrastructure.Interfaces
{
    public interface ILoggerService<TController> where TController: class
    {
        void LogInformation(string message, object obj);
        void LogWarning(string message, object obj);
        void LogError(string message, object obj);
        void LogCritical(string message, object obj);
    }
}
