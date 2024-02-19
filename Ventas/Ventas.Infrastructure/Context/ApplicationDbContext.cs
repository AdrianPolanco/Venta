using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    /// <summary>
    /// Es el contexto que representa toda la base de datos de la apllicacion
    /// </summary>
    public partial class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///<summary>
            ///Configurando la tabla Venta
            /// </summary>
            
            modelBuilder.Entity<Sale>(sales => {
                sales.HasKey(s => s.idVenta);

                sales.Property(s => s.numeroDocumento).HasMaxLength(40);
                sales.Property(s => s.tipoPago).HasMaxLength(50);
                sales.Property(s => s.fechaRegistro).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                sales.Property(s => s.total).HasColumnType("decimal(10,2)");
                });

            ///<summary>
            ///Configurando la tabla Usuario
            /// </summary>

            modelBuilder.Entity<User>(users =>
            {
                users.HasKey(u => u.idUsuario);
                users.Property(u => u.nombreCompleto).HasMaxLength(100);
                users.Property(u => u.correo).HasMaxLength(40);
                users.Property(u => u.clave).HasMaxLength(40);
                users.Property(u => u.FechaElimino).HasColumnType("datetime");
                users.Property(u => u.FechaMod).HasColumnType("datetime");
                users.Property(u => u.fechaRegistro).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>().HasOne(u => u.Role).WithOne().HasForeignKey<User>(u => u.idRol);

        }
    }
}
