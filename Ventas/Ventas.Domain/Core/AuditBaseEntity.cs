

namespace Ventas.Domain.Core
{
    public abstract class AuditBaseEntity
    {
        public DateTime fechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool? Eliminado { get; set; }
    }
}
