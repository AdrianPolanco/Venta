using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> Create(Producto Producto);
        Task<Producto?> Update(Producto Producto, int currentSaleId);
        Task<Producto?> Delete(Producto Producto);

        Task<List<Producto>> GetProducto();
        Task<Producto?> GetProducto(int id);
    }
}
