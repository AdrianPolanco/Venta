
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class User: AuditBaseEntity
    {
        public int idUsuario { get; set; }
        public string nombreCompleto { get; set; } = null!;
        public string correo { get; set; } = null!;
        public int idRol{ get; set; }
        public virtual Role Role { get; set; } = null!;
        public string clave { get; set; } = null!;
        public bool esActivo { get; set; }

    }
}
