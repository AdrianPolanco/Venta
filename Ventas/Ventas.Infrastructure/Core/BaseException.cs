

namespace Ventas.Infrastructure.Core
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message) 
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
