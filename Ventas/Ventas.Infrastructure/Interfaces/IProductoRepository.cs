using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> Create(Producto Producto);
        Task<Producto?> Update(Producto Producto, int currentProductoId);
        Task<Producto?> Delete(Producto Producto);

        Task<List<Producto>> GetProductos();
        Task<Producto?> GetProducto(int id);
    }
}
