using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Entities.Categoria;

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
