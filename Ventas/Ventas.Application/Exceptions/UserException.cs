

namespace Ventas.Application.Exceptions
{
    internal class UserException: Exception
    {
        internal UserException(string message): base($"Error en usuarios: $¡{message}")
        {
            
        }
    }
}
