using Ventas.Application.Contracts.Factories;

namespace Ventas.Application.Exceptions.Factories
{
    public class SaleExceptionFactory : IExceptionFactory
    {
        public Exception CreateException(string message)
        {
            return new SaleException(message);
        }
    }
}
