using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product Producto);
        Task<Product?> Update(Product Producto, int currentProductoId);
        Task<Product?> Delete(Product Producto);

        Task<List<Product>> GetProductos();
        Task<Product?> GetProducto(int id);
    }
}
