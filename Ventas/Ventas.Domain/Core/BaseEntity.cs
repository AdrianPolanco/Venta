

namespace Ventas.Domain.Core
{
    public abstract class BaseEntity
    {

        public DateTime? fecha_registro { get; set; }

        public int? IdUsuarioCreacion { get; set; }

        public DateTime? fechaModificiacion { get; set; }

        public int? idUsuarioModificacion { get; set; }

        public int? idUsuarioEliminado { get; set; }

        public DateTime? fechaEliminado { get; set; }

        public bool? eliminado { get; set; }


    }
}
