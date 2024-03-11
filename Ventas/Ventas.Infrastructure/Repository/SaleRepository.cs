using Microsoft.EntityFrameworkCore;
using Ventas.Application.Contracts.Repositories;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;

namespace Ventas.Infrastructure.Repository
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context) : base(context) { }


        /// <summary>
        /// Actualizando una venta, en caso de que exista
        /// </summary>
        /// <param name="sale">Los nuevos datos que tendra la venta</param>
        /// <param name="currentSaleId">El id de la venta que se quiere actualizar</param>
        /// <returns>Venta actualizada</returns>
        public override async Task<Sale?> Update(Sale sale, int currentSaleId)
        {
            try
            {
                bool saleExists = await base.Exists(s => s.idVenta == currentSaleId);
                if (!saleExists) return null;

                Sale foundSale = await _dbContext.Venta.FindAsync(currentSaleId);

                foundSale.numeroDocumento = sale.numeroDocumento;
                foundSale.tipoPago = sale.tipoPago;
                foundSale.total = sale.total;

                await _dbContext.SaveChangesAsync();

                return foundSale;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Borrando una venta, en caso de que exista
        /// </summary>
        /// <param name="sale">La venta que se quiere eliminar</param>
        /// <returns>Venta borrada</returns>
        public override async Task<Sale?> Delete(int id)
        {
            try
            {
                bool saleExists = await base.Exists(s => s.idVenta == id);
                if (!saleExists) return null;

                Sale deletedSale = await base.Delete(id);
                return deletedSale;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Obteniendo una venta por su id
        /// </summary>
        /// <param name="id">Id d la venta que se quiere obtener</param>
        /// <returns>Venta coincidente con el id</returns>
        public override async Task<Sale?> GetEntity(int id)
        {
            try
            {
                bool saleExists = await base.Exists(s => s.idVenta == id);
                if (!saleExists) return null;

                Sale foundSale = await base.GetEntity(id);

                return foundSale;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Obteniendo ventas por fecha de registro
        /// </summary>
        /// <returns>Ventas en orden de fecha de registro</returns>
        public async Task<List<Sale>> GetByDate(bool isDescending)
        {
            try
            {
                List<Sale> sales;
                if (!isDescending)
                {
                    sales = await _dbContext.Venta.OrderBy(v => v.fechaRegistro).ToListAsync();
                }
                else
                {
                    sales = await _dbContext.Venta.OrderByDescending(v => v.fechaRegistro).ToListAsync();
                }

                return sales;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Obteniendo ventas por total
        /// </summary>
        /// <returns>Ventas en orden de monto total</returns>
        public async Task<List<Sale>> GetByTotal(bool isDescending)
        {
            try
            {
                List<Sale> sales;
                if (!isDescending)
                {
                    sales = await _dbContext.Venta.OrderBy(v => v.total).ToListAsync();
                }
                else
                {
                    sales = await _dbContext.Venta.OrderByDescending(v => v.total).ToListAsync();
                }

                return sales;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}