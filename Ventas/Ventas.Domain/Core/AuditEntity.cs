
namespace Ventas.Domain.Core
{
    /// <summary>
    /// Clase base para las entidades con los campos correspondientes tanto a esta clase como a AuditBaseEntity
    /// </summary>
    public abstract class AuditEntity: AuditBaseEntity
    {
        public int? IdUsuarioCreacion { get; set; }
        public int? IdUsuarioMod {  get; set; }
        public int? IdUsuarioElimino { get; set; }


    }
}
