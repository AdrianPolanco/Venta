using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    /// <summary>
    /// Tablas de Venta y Usuario agregadas aquí, para mayor claridad y organización.
    /// Agregado por: Adrian Polanco Ferrer, matrícula 2023-0222
    /// </summary>
    
    public partial class ApplicationDbContext
    {
        public DbSet<Sale> Venta { get; set; }
        public DbSet<User> Usuario { get; set; }

        public DbSet<Product> Producto { get; set; }
        public DbSet<DocumentNumber> NumeroDocumento { get; set; }

    }
}
