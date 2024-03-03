using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public int categoria_id { get; set; }
        public string? categoria_Nombre { get; set; }

        public bool? categoria_Activo { get; set; }

    }
}
