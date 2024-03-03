using Ventas.Domain.Entities;
using Ventas.Domain.Repositories;
using Ventas.Infrastructure.Models;
namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {

        
        List<ProductModel> GetProductsByCategory(int categoryId);
        List<ProductModel> GetProductsBySupplier(int supplierId);



    }
}
