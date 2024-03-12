using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Models.Sales;

namespace Ventas.Application.Contracts.Services
{
    public interface ISaleService : IBaseService
    {
        Task<ServiceResult> GetAll();
        Task<ServiceResult> GetById(int id);
        Task<ServiceResult> Create(SaleCreateDto sale);
        Task<ServiceResult> Update(SaleUpdateDto sale);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> GetByDate(bool isDescending);
        Task<ServiceResult> GetByTotal(bool isDescending);
    }
}
