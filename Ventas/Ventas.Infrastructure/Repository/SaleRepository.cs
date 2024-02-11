using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class SaleRepository: ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creando una venta en la BD
        /// </summary>
        /// <param name="sale">Venta que se quiere crear</param>
        /// <returns>Venta creada</returns>
        public async Task<Sale> Create(Sale sale)
        {
            await _context.Venta.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        /// <summary>
        /// Actualizando una venta, en caso de que exista
        /// </summary>
        /// <param name="sale">Los nuevos datos que tendra la venta</param>
        /// <param name="currentSaleId">El id de la venta que se quiere actualizar</param>
        /// <returns>Venta actualizada</returns>
        public async Task<Sale?> Update(Sale sale, int currentSaleId)
        {
            bool saleExists = _context.Venta.Any<Sale>(s => s.idVenta == currentSaleId);
            if (!saleExists) return null;

            Sale foundSale = await _context.Venta.FindAsync(currentSaleId);

            foundSale.numeroDocumento = sale.numeroDocumento;
            foundSale.tipoPago = sale.tipoPago;
            foundSale.total = sale.total;

            await _context.SaveChangesAsync();

            return foundSale;
        }

        /// <summary>
        /// Borrando una venta, en caso de que exista
        /// </summary>
        /// <param name="sale">La venta que se quiere eliminar</param>
        /// <returns>Venta borrada</returns>
        public async Task<Sale?> Delete(Sale sale)
        {
            bool saleExists = _context.Venta.Any<Sale>(s => s.idVenta == sale.idVenta);
            if (!saleExists) return null;

            _context.Venta.Remove(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        /// <summary>
        /// Obteniendo una venta por su id
        /// </summary>
        /// <param name="id">Id d la venta que se quiere obtener</param>
        /// <returns>Venta coincidente con el id</returns>
        public async Task<Sale?> GetSale(int id)
        {
            bool saleExists = _context.Venta.Any<Sale>(s => s.idVenta == id);
            if (!saleExists) return null;

            Sale foundSale = await _context.Venta.FindAsync(id);

            return foundSale;
        }

        /// <summary>
        /// Obteniendo todas las ventas existentes
        /// </summary>
        /// <returns>Todas las ventas</returns>
        public async Task<List<Sale>> GetSales()
        {
            List<Sale> sales = await _context.Venta.ToListAsync();
            return sales;
        }

    }
}

