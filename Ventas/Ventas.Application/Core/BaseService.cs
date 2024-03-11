

using System.Reflection;
using Ventas.Application.Contracts.Factories;
using Ventas.Infrastructure.Exceptions;

namespace Ventas.Application.Core
{
    public class BaseService : IBaseService
    {
        protected ServiceResult SetResult(ServiceResult result, bool success, string message, object data = null)
        {
            result.Success = success;
            result.Message = message;
            result.Result = data;

            return result;
        }

        public virtual bool ValidateFields<Dto>(Dto dto, Dictionary<string, int> validations, IExceptionFactory exceptionFactory)
        {
            PropertyInfo[]? properties = typeof(Dto).GetProperties();
            properties.FirstOrDefault(p =>
            {
                if (validations.ContainsKey(p.Name))
                {
                    if (validations[p.Name] < p.GetValue(dto).ToString().Length) throw exceptionFactory.CreateException($"La cantidad máxima de caracteres permitidos fue excedida en {p.Name}");
                    
                }
                return false;
            });

            return true;
        }

    }
}
