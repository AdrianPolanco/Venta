

using System.Runtime.CompilerServices;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extensions
{
    public static  class SaleExtension
    {
        public static Sale ToSale(this SaleModel saleModel)
        {
            return new Sale
            {
                numeroDocumento = saleModel.numeroDocumento,
                tipoPago = saleModel.tipoPago,
                total = saleModel.total,
            };
        }

        public static List<Sale> ToSales(this List<SaleModel> salesModels)
        {
            List<Sale> list = salesModels.Select(s => new Sale
            {
                numeroDocumento = s.numeroDocumento,
                tipoPago = s.tipoPago,
                total = s.total,
            }).ToList();

            return list;
        }

        public static List<SaleModel> ToSalesModels(this List<Sale> sales)
        {
            List<SaleModel> list = sales.Select(s => new SaleModel
            {
                numeroDocumento = s.numeroDocumento,
                tipoPago = s.tipoPago,
                total = s.total,
                fechaRegistro = s.fechaRegistro,
            }).ToList();

            return list;
        }

        public static SaleModel ToSaleModel(this Sale sale)
        {
            return new SaleModel
            {
                numeroDocumento = sale.numeroDocumento,
                tipoPago = sale.tipoPago,
                total = sale.total,
                fechaRegistro = sale.fechaRegistro
            };
        }
    }
}
