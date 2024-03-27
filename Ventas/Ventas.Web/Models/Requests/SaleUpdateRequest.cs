namespace Ventas.Web.Models.Requests
{
    public class SaleUpdateRequest
    {
        public int Id { get; set; }
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
