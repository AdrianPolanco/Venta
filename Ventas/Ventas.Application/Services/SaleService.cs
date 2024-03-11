using Ventas.Application.Core;
using Ventas.Application.Dtos.Sales;
using Ventas.Application.Exceptions;
using Ventas.Application.Extensions.Dtos;
using Ventas.Application.Extensions.Models;
using Ventas.Application.Models.Sales;
using Ventas.Domain.Entities;
using Ventas.Application.Messages;
using Ventas.Application.Models.Base;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Contracts.Services;
using Ventas.Application.Contracts.Factories;
using Ventas.Application.Exceptions.Factories;

namespace Ventas.Application.Services
{
    public class SaleService: BaseService, ISaleService
    {
        private ISaleRepository _saleRepository;
        private IExceptionFactory _exceptionFactory;
        public SaleService(ISaleRepository saleRepository) {
            _saleRepository = saleRepository;
            _exceptionFactory = new SaleExceptionFactory();
        }

        public async Task<ServiceResult> CreateSale(SaleCreateDto saleDto)
        {
            Dictionary<string, int> validations = new Dictionary<string, int>() {
                {"numeroDocumento", 40 },
                {"tipoPago", 50 },
                {"total",11}
            };
            ServiceResult result = new();
            try
            {
               bool validationPassed = this.ValidateFields(saleDto, validations, _exceptionFactory);

               
               Sale sale = saleDto.ToSale();
               Sale savedSale = await _saleRepository.Create(sale);
               SaleCreateModel createdSaleModel = savedSale.ToCreateSaleModel();

               result = this.SetResult(result, true, StatusMessages.POST_SUCCESS, createdSaleModel);
            }
            catch(SaleException ex)
            {
                result = this.SetResult(result, false, StatusMessages.POST_INVALID, ex.Message);
            } 
            
               return result;       
        }

        public async Task<ServiceResult> DeleteSale(int id)
        {
            ServiceResult result = new();
            try
            {
                Sale? sale = await _saleRepository.Delete(id);

                if (sale == null)
                {
                    result = this.SetResult(result, false, StatusMessages.DELETE_NOTFOUND, sale);
                    return result;
                };

                result = this.SetResult(result, true, StatusMessages.DELETE_SUCCESS, sale);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.DELETE_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetAllSales()
        {
            ServiceResult result = new();
            try
            {
                List<Sale> sales = await _saleRepository.GetEntities();
                List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, salesModels);
            }catch(Exception ex){
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetByDate(bool isDescending)
        {

            ServiceResult result = new();
            try
            {
                List<Sale> sales = await _saleRepository.GetByDate(isDescending);
                List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, salesModels);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetByTotal(bool isDescending)
        {


                ServiceResult result = new();
                try
                {
                    List<Sale> sales = await _saleRepository.GetByTotal(isDescending);
                    List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                    result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, salesModels);
                }
                catch (Exception ex)
                {
                    result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
                }

                return result;
            }

        public async Task<ServiceResult> GetSaleById(int id)
        {
                ServiceResult result = new();
                try
                {
                    Sale? sale = await _saleRepository.GetEntity(id);

                    if (sale == null)
                    {
                        result = this.SetResult(result, false, StatusMessages.GET_NOTFOUND, sale);
                        return result;
                    };

                    SaleGetModel saleModel = sale.ToGetSaleModel();
                    result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, saleModel);

                }
                catch (Exception ex)
                {
                    result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
                }
                return result;
        }
                
          
        public async Task<ServiceResult> UpdateSale(SaleUpdateDto saleDto)
        {
            Dictionary<string, int> validations = new Dictionary<string, int>() {
                {"numeroDocumento", 40 },
                {"tipoPago", 50 },
                {"total",11}
            };
            ServiceResult result = new();
            try
            {
                bool validationPassed = this.ValidateFields(saleDto, validations, _exceptionFactory);

                Sale? sale = saleDto.ToSale();
                Sale? updatedSale = await _saleRepository.Update(sale, saleDto.Id);

                if (updatedSale == null)
                {
                    result = this.SetResult(result, false, StatusMessages.PUT_INVALID);
                    return result;
                };

                sale.idVenta = saleDto.Id;

                SaleGetModel saleModel = sale.ToGetSaleModel();
                result = this.SetResult(result, true, StatusMessages.PUT_SUCCESS, saleModel);

            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.PUT_INVALID, ex.Message);
            }
            return result;
        }

    }
}
