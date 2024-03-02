

using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repositoy
{
    public class DetalleventaRepositoy : IDetalleVentaRepository
    {
        private readonly VentaContext context;
        public DetalleventaRepositoy(VentaContext context)
        {
            this.context = context;
        }
        public void Create(Detalleventa detalleventa)
        {

            try
            {

                this.context.DetalleVenta.Add(detalleventa);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }
           
        }

        public List<Detalleventa> GetDetalleventa()
        {
            return this.context.DetalleVenta.ToList();
        }

        public Detalleventa? GetDetalleventa(int idDetalleVenta)
        {
            return this.context.DetalleVenta.Find(idDetalleVenta);
        }


        //aqui
        public void Remove(Detalleventa detalleventa)
        {


            try
            {

                var detalleventaToRemove = this.GetDetalleventa(detalleventa.idDetalleVenta);


                this.context.DetalleVenta.Update(detalleventa);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }

           
        }

        //aqui
        public void Update(Detalleventa detalleventa)
        {



            try
            {
                var detalleventaToRemove = this.GetDetalleventa(detalleventa.idDetalleVenta);


                this.context.DetalleVenta.Update(detalleventa);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }
           
        }
    }
}
