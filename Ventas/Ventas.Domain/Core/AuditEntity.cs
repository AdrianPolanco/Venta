
using Ventas.Domain.Entities;

namespace Ventas.Domain.Core
{
    public abstract class AuditEntity: AuditBaseEntity
    {

        public int? IdUsuarioCreacion { get; set; }
        public int? IdUsuarioMod {  get; set; }
        public int? IdUsuarioElimino { get; set; }


    }
}
