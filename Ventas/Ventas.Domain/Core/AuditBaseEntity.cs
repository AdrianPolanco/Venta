

namespace Ventas.Domain.Core
{
    /// <summary>
    /// Clase base para las entidades que tienen AL MENOS estas 4 columnas
    /// </summary>
    public abstract class AuditBaseEntity
    {
        public DateTime fechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool? Eliminado { get; set; }
    }
}
