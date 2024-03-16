using Ventas.Application.Core;

namespace Ventas.Application.Contracts.Services
{
    public interface ISaleService<TCreateDto, TUpdateDto> : IBaseService, IService<TCreateDto, TUpdateDto>
    {

        Task<ServiceResult> GetByTotal(bool isDescending);
    }
}
