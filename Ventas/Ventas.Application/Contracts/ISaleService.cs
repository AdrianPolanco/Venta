using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Models.Sales;

namespace Ventas.Application.Contracts
{
    public interface ISaleService: IBaseService
    {
        Task<List<SaleGetModel>> GetAllSales();
        Task<SaleGetModel?> GetSaleById(int id);
        Task<SaleCreateModel> CreateSale(SaleCreateDto sale);
        Task<SaleUpdateModel> UpdateSale(SaleUpdateDto sale);
        Task DeleteSale(int id);
        Task<List<SaleGetModel>> GetByDate(bool isDescending);
        Task<List<SaleGetModel>> GetByTotal(bool isDescending);
    }
}
