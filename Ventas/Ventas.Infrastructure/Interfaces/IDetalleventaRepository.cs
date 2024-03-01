
//interface conectada a la entidad de dominio detalle venta

using Ventas.Domain.Entities;
using Ventas.Domain.Repositories;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IDetalleVentaRepository 
    {

        void Create(Detalleventa detalleventa);
        void Update(Detalleventa detalleventa);
        void Remove(Detalleventa detalleventa);

        List<Detalleventa> GetDetalleventa();

        Detalleventa GetDetalleventa(int idDetalleVenta);
    }
}
