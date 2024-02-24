using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public Task<Producto> Create(Producto Producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto?> Delete(Producto Producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto?> GetProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Task<Producto?> Update(Producto Producto, int currentProductoId)
        {
            throw new NotImplementedException();
        }
    }

}
