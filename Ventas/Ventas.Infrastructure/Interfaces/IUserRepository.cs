
using Ventas.Domain.Entities;
using Ventas.Domain.Repositories;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<List<User>> GetByName();
        Task<List<User>> GetByRole();
        Task<List<User>> GetByDate();
    }
}
