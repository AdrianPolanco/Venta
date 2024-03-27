using Ventas.Web.Models.Requests;

namespace Ventas.Web.Models.Responses
{
    public class SaleGetResponse
    {
        public int Id { get; set; }
        public string numeroDocumento { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public DateTime fechaRegistro { get; set; }
    }

    public static class SaleMapper
    {
        public static SaleUpdateRequest ToUpdateSaleRequest(this SaleGetResponse saleGetResponse)
        {
            return new SaleUpdateRequest
            {
                Id = saleGetResponse.Id,
                numeroDocumento = saleGetResponse.numeroDocumento,
                tipoPago = saleGetResponse.tipoPago,
                total = saleGetResponse.total,
                fechaRegistro = saleGetResponse.fechaRegistro,
            };
        }
    }
}
