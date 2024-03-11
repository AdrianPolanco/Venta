using Ventas.Application.Dtos.Sales;
using Ventas.Application.Models.Users;


namespace Ventas.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<List<UserGetModel>> GetAllSales();
        Task<UserGetModel> GetSaleById(int id);
        Task<UserUpdateModel> UpdateSale(SaleUpdateDto sale);
        Task DeleteSale(int id);
        Task<List<UserUpdateModel>> GetByName(bool isDescending);
        Task<List<UserUpdateModel>> GetByRole(bool isDescending);
        Task<List<UserUpdateModel>> GetByDate(bool isDescending);
    }
}
