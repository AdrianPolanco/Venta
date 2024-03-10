

using System.Reflection;
using Ventas.Infrastructure.Exceptions;

namespace Ventas.Application.Core
{
    public class BaseService : IBaseService
    {


        public virtual bool ValidateFields<Dto>(Dto dto, Dictionary<string, int> validations)
        {
            PropertyInfo[]? properties = typeof(Dto).GetProperties();
            properties.FirstOrDefault(p =>
            {
                if (validations.ContainsKey(p.Name))
                {
                    if (validations[p.Name] < p.GetValue(dto).ToString().Length) throw new UserException($"La cantidad máxima de caracteres permitidos fue excedida en {p.Name}");
                    
                }
                return false;
            });

            return true;
        }

    }
}
