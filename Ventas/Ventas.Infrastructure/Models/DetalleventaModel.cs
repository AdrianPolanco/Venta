
namespace Ventas.Infrastructure.Models
{
    internal class DetalleVentaModel
    {


        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; } 
    }
}
