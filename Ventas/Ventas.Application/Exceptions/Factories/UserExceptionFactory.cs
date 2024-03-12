using Ventas.Application.Contracts.Factories;

namespace Ventas.Application.Exceptions.Factories
{
    public class UserExceptionFactory : IExceptionFactory
    {
        public Exception CreateException(string message)
        {
            return new UserException(message);
        }
    }
}
