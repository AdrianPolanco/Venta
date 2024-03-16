

namespace Ventas.Application.Exceptions
{
    public class SaleException: Exception
    {
        public SaleException(string message): base($"Error en ventas: $¡{message}")
        {
            
        }
    }
}
