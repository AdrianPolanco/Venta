namespace Ventas.Web.Models.Requests
{
    public class SaleCreateRequest
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
    }
}
