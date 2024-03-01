

using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentaContext : DbContext
    {

       
        public VentaContext(DbContextOptions<VentaContext> options) : base(options)
        {

        }
        
       public DbSet<Detalleventa> DetalleVenta { get; set; }
        public DbSet<Menu> Menu { get; set; }

    }

     
    

     
    
}
