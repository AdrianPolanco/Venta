

using System.Reflection;

namespace Ventas.Application.Core
{
    public interface IBaseService
    {

        bool ValidateFields<Dto>(Dto dto, Dictionary<string, int> validations);

    }
}
