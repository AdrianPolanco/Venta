using Ventas.Application.Dtos.Base;

namespace Ventas.Application.Dtos.Sales
{
    public record SaleUpdateDto : BaseSaleDto
    {
        public int Id { get; set; }
    }
}
