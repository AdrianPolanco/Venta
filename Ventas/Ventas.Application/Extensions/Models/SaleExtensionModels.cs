
using Ventas.Domain.Entities;
using Ventas.Application.Models.Sales;

namespace Ventas.Application.Extensions.Models
{
    /// <summary>
    /// Metodos de extension corrrespondientes a Sales o Ventas
    /// </summary>
    public static class SaleExtensionModels
    {
        public static SaleGetModel ToGetSaleModel(this Sale sale)
        {
            return new SaleGetModel
            {
                Id = sale.idVenta,
                numeroDocumento = sale.numeroDocumento,
                tipoPago = sale.tipoPago,
                total = sale.total,
                fechaRegistro = sale.fechaRegistro,
            };
        }

        public static List<SaleGetModel> ToGetSalesModels(this List<Sale> sales)
        {
            List<SaleGetModel> list = sales.Select(s => new SaleGetModel
            {
                Id = s.idVenta,
                numeroDocumento = s.numeroDocumento,
                tipoPago = s.tipoPago,
                total = s.total,
                fechaRegistro = s.fechaRegistro
            }).ToList();

            return list;
        }

        public static SaleCreateModel ToCreateSaleModel(this Sale sale)
        {
            return new SaleCreateModel
            {
                Id = sale.idVenta,
                numeroDocumento = sale.numeroDocumento,
                tipoPago = sale.tipoPago,
                total = sale.total,
                fechaRegistro = sale.fechaRegistro
            };
        }

        public static SaleUpdateModel ToUpdateSaleModel(this Sale sale)
        {
            return new SaleUpdateModel
            {
                Id = sale.idVenta,
                numeroDocumento = sale.numeroDocumento,
                tipoPago = sale.tipoPago,
                total = sale.total,
                fechaRegistro = sale.fechaRegistro
            };
        }
    }
}
