
using Ventas.Domain.Entities;
using Ventas.Domain.Repositories;

namespace Ventas.Infrastructure.Interfaces
{
    public interface ISaleRepository: IBaseRepository<Sale>
    {
        Task<List<Sale>> GetByDate(bool isDescending);
        Task<List<Sale>> GetByTotal(bool isDescending);
    }
}
