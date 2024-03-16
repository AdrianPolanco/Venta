using Ventas.Application.Core;


namespace Ventas.Application.Contracts.Services
{
    public interface IUserService<TCreateDto, TUpdateDto> : IBaseService, IService<TCreateDto, TUpdateDto>
    {
        Task<ServiceResult> GetByName(bool isDescending);
        Task<ServiceResult> GetByRole(bool isDescending);
    }
}
