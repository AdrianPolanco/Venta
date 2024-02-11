
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> Create(Sale sale);
        Task<Sale?> Update(Sale sale, int currentSaleId);
        Task<Sale?> Delete(Sale sale);

        Task<List<Sale>> GetSales();
        Task<Sale?> GetSale(int id);
    }
}
