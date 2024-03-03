namespace Ventas.Api.Dtos.Base
{
    public abstract class BaseSaleDto
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
    }
}
