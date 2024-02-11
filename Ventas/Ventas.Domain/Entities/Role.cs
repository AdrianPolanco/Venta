using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Role : AuditEntity
    {
        public int idRol { get; set; }
        public string nombre { get; set; } = null!;

    }
}
