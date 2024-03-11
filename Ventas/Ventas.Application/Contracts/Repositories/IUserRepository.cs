using Ventas.Domain.Entities;
using Ventas.Domain.Repositories;

namespace Ventas.Application.Contracts.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetByName(bool isDescending);
        Task<List<User>> GetByRole(bool isDescending);
        Task<List<User>> GetByDate(bool isDescending);
    }
}
