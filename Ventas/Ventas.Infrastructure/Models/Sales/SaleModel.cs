using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Models.Sales
{
    public class SaleModel
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
