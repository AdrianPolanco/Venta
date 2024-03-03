
using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {

        }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<MenuRol> MenuRol { get; set; }
    }
}
