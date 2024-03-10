namespace Ventas.Application.Dtos.Base
{
    public abstract record BaseSaleDto
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
    }
}
