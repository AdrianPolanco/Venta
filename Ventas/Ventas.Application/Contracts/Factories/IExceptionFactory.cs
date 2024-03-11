namespace Ventas.Application.Contracts.Factories
{
    public interface IExceptionFactory
    {
        Exception CreateException(string message);
    }
}
