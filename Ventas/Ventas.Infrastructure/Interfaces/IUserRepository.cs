
using Ventas.Domain.Entities;


namespace Ventas.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> Update(User user, int currentUserId);
        Task<User?> Delete(User user);

       Task<List<User>> GetUsers();
        Task<User?> GetUser(int id);
    }
}
