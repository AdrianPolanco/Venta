
using Ventas.Api.Dtos.Base;
using Ventas.Domain.Entities;

namespace Ventas.Api.Extensions.Dtos
{
    public static class SaleExtensionDtos
    {
        public static Sale ToSale(this BaseSaleDto saleCreateDto)
        {
            return new Sale
            {
                numeroDocumento = saleCreateDto.numeroDocumento,
                tipoPago = saleCreateDto.tipoPago,
                total = saleCreateDto.total,
            };
        }
    }
}
