using Ventas.Application.Contracts;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Exceptions;
using Ventas.Application.Extensions.Dtos;
using Ventas.Application.Extensions.Models;
using Ventas.Application.Models.Sales;
using Ventas.Domain.Entities;

namespace Ventas.Application.Services
{
    public class SaleService: BaseService, ISaleService
    {
        private ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository) {
            _saleRepository = saleRepository;
        }

        public async Task<SaleCreateModel> CreateSale(SaleCreateDto saleDto)
        {
            Dictionary<string, int> validations = new Dictionary<string, int>() {
                {"numeroDocumento", 40 },
                {"tipoPago", 50 },
                {"total",11}
            };
            try
            {
               this.ValidateFields<SaleCreateDto>(saleDto, validations);

               Sale sale = saleDto.ToSale();
               Sale savedSale = await _saleRepository.Create(sale);
               SaleCreateModel createdSaleModel = savedSale.ToCreateSaleModel();
               return createdSaleModel;
                
            }
            catch(SaleException ex)
            {
                throw;
            }       
        }

        public async Task DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SaleGetModel>> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SaleGetModel>> GetByDate(bool isDescending)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SaleGetModel>> GetByTotal(bool isDescending)
        {
            throw new NotImplementedException();
        }

        public async Task<SaleGetModel> GetSaleById(int id)
        {
            try
            {
                Sale? sale = await _saleRepository.GetEntity(id);

                if (sale == null) return null;

                SaleGetModel saleModel = sale.ToGetSaleModel();

                return saleModel;
            }
            catch(SaleException ex)
            {
                throw;
            }
        }

        public async Task<SaleUpdateModel> UpdateSale(SaleUpdateDto sale)
        {
            throw new NotImplementedException();
        }

    }
}
