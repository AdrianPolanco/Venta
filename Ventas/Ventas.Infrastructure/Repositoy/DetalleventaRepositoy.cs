

using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repositoy
{
    public class DetalleventaRepositoy : IDetalleVentaRepository
    {

        public DetalleventaRepositoy(VentaContext context)
        {
            
        }
        public void Create(Detalleventa detalleventa)
        {
            throw new NotImplementedException();
        }

        public List<Detalleventa> GetDetalleventa()
        {
            throw new NotImplementedException();
        }

        public Detalleventa GetDetalleventa(int idDetalleVenta)
        {
            throw new NotImplementedException();
        }

        public void Remove(Detalleventa detalleventa)
        {
            throw new NotImplementedException();
        }

        public void Update(Detalleventa detalleventa)
        {
            throw new NotImplementedException();
        }
    }
}
