namespace Ventas.Api.Models.Base
{
    public abstract class BaseSaleModel: BaseModel
    {
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
