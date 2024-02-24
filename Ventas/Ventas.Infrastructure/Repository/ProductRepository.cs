using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creando un producto en la BD
        /// </summary>
        /// <param name="producto">producto que se quiere crear</param>
        /// <returns>producto creado</returns>
        public async Task<Product> Create(Product producto)
        {
            await _context.Producto.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /// <summary>
        /// Borrando un producto, en caso de que exista
        /// </summary>
        /// <param name="producto">El producto que se quiere eliminar</param>
        /// <returns>Producto borrado</returns>
        public async Task<Product?> Delete(Product producto)
        {
            bool productExists = _context.Producto.Any<Product>(p => p.idProducto == producto.idProducto);
            if (!productExists) return null;

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return producto;
        }


        /// <summary>
        /// Obteniendo un producto por su id
        /// </summary>
        /// <param name="id">Id del producto que se quiere obtener</param>
        /// <returns>Producto coincidente con el id</returns>
        public async Task<Product?> GetProducto(int id)
        {
            bool productExists = _context.Producto.Any<Product>(p => p.idProducto == id);
            if (!productExists) return null;

            Product foundProduct = await _context.Producto.FindAsync(id);

            return foundProduct;
        }

        /// <summary>
        /// Obteniendo todas los productos existentes
        /// </summary>
        /// <returns>Todos los productos</returns>
        public async Task<List<Product>> GetProductos()
        {
            List<Product> products = await _context.Producto.ToListAsync();
            return products;
        }


        /// <summary>
        /// Actualizando un producto, en caso de que exista
        /// </summary>
        /// <param name="producto">Los nuevos datos que tendra la venta</param>
        /// <param name="currentSaleId">El id de la venta que se quiere actualizar</param>
        /// <returns>Venta actualizada</returns>
        public async Task<Product?> Update(Product producto, int currentProductoId)
        {
            bool productExists = _context.Producto.Any<Product>(p => p.idProducto == currentProductoId);
            if (!productExists) return null;
                
            Product foundProducto = await _context.Producto.FindAsync(currentProductoId);

            foundProducto.idProducto = producto.idProducto;
            foundProducto.esActivo = producto.esActivo;
            foundProducto.FechaMod = producto.FechaMod;
            foundProducto.fechaRegistro = producto.fechaRegistro;

            await _context.SaveChangesAsync();

            return foundProducto;
        }
    }
}
