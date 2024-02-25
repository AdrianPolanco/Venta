using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    /// <summary>
    /// Clase creada debido a la relacion de la tabla Usuario con la tabla Rol
    /// </summary>
    public class Role : AuditEntity
    {
        public int idRol { get; set; }
        public string nombre { get; set; } = null!;

    }
}
