using Ventas.Domain.Core;

namespace Ventas.Domain.Entities : 
{
    public class Rol : BaseEntityA
    {
        public string? nombre { get; set; }
        public DateTime? fechaRegistro { get; set; }
    }
}
