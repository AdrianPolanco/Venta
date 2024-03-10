namespace Ventas.Application.Models.Base
{
    public abstract record BaseSaleModel : BaseModel
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
