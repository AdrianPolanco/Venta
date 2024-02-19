

namespace Ventas.Domain.Entities
{
    public class Sale
    {
        //Las entidades de dominio no deberían de tener lógica
        public int idVenta { get; set; }
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}
