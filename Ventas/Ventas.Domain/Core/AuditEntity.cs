
using Ventas.Domain.Entities;

namespace Ventas.Domain.Core
{
    public abstract class AuditEntity: AuditBaseEntity
    {

        public int? IdUsuarioCreacion { get; set; }
        public virtual User? UsuarioCreacion { get; set; }
        public int? IdUsuarioMod {  get; set; }

        public virtual User? UsuarioMod{ get; set; }

        public int? IdUsuarioElimino { get; set; }

        public virtual User? UsuarioElimino{ get; set; }


    }
}
