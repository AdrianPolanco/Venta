using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Models.Sales;

namespace Ventas.Application.Contracts.Services
{
    public interface ISaleService : IBaseService
    {
        Task<ServiceResult> GetAllSales();
        Task<ServiceResult> GetSaleById(int id);
        Task<ServiceResult> CreateSale(SaleCreateDto sale);
        Task<ServiceResult> UpdateSale(SaleUpdateDto sale);
        Task<ServiceResult> DeleteSale(int id);
        Task<ServiceResult> GetByDate(bool isDescending);
        Task<ServiceResult> GetByTotal(bool isDescending);
    }
}
