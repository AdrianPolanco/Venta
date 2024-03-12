using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Dtos.Users;

namespace Ventas.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<ServiceResult> GetAll();
        Task<ServiceResult> GetById(int id);
        Task<ServiceResult> Create(UserCreateDto userDto);
        Task<ServiceResult> Update(UserUpdateDto userDto);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> GetByName(bool isDescending);
        Task<ServiceResult> GetByRole(bool isDescending);
        Task<ServiceResult> GetByDate(bool isDescending);
    }
}
