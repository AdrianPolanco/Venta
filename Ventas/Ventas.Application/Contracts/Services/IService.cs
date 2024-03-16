using Ventas.Application.Core;


namespace Ventas.Application.Contracts.Services
{
    public interface IService<TCreateDto, TUpdateDto>
    {
        Task<ServiceResult> GetAll();
        Task<ServiceResult> GetById(int id);
        Task<ServiceResult> Create(TCreateDto dto);
        Task<ServiceResult> Update(TUpdateDto dto);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> GetByDate(bool isDescending);
    }
}
