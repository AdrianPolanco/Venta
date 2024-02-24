using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> Create(Product Producto)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> Delete(Product Producto)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> Update(Product Producto, int currentProductoId)
        {
            throw new NotImplementedException();
        }
    }
}
