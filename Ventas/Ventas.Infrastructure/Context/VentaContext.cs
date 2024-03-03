using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentaContext : DbContext
    {
        public VentaContext(DbContextOptions<VentaContext> options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }


    }
}
