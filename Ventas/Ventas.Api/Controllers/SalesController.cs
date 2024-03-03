using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;
using Ventas.Api.Models.Sales;
using Ventas.Api.Extensions.Models;
using Ventas.Api.Dtos.Sales;
using Ventas.Api.Extensions.Dtos;
using Ventas.Infrastructure.ObjectQueries;

namespace Ventas.Api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private ILoggerService<ISaleRepository> _logger;

        public SalesController(ISaleRepository saleRepository, ILoggerService<ISaleRepository> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Sale> sales = await _saleRepository.GetEntities();
                List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                Sale? sale = await _saleRepository.GetEntity(id);

                if (sale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                SaleGetModel saleModel = sale.ToGetSaleModel();

                _logger.LogInformation("Venta encontrada: ", saleModel);
                return Ok(saleModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("/dates")]
        public async Task<IActionResult> GetByDate([FromQuery] SortQuery query)
        {
            try
            {
                List<Sale> sales = await _saleRepository.GetByDate(query.IsDescending);
                List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("/totals")]
        public async Task<IActionResult> GetByTotal([FromQuery] SortQuery query)
        {
            try
            {
                List<Sale> sales = await _saleRepository.GetByTotal(query.IsDescending);
                List<SaleGetModel> salesModels = sales.ToGetSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleCreateDto saleDto)
        {
            try
            {
                Sale sale = saleDto.ToSale();
                Sale savedSale = await _saleRepository.Create(sale);
                _logger.LogInformation("Nueva venta guardada", savedSale);

                SaleCreateModel createdSaleModel = savedSale.ToCreateSaleModel();

                return CreatedAtAction(nameof(GetById), new { id = savedSale.idVenta}, createdSaleModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

        [HttpPut]
        public async Task<IActionResult>Update([FromBody] SaleUpdateDto saleDto)
        {
            try
            {
                Sale sale = saleDto.ToSale();
                Sale? updatedSale = await _saleRepository.Update(sale, saleDto.Id);

                if(updatedSale == null) return NotFound($"Venta no encontrada: Venta con el id {saleDto.Id} no existente.");

                SaleUpdateModel saleUpdateModel = updatedSale.ToUpdateSaleModel();

                _logger.LogInformation("Venta actualizada con exito: ", saleUpdateModel);

                return Ok(saleUpdateModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                Sale? deletedSale = await _saleRepository.Delete(id);
                
                 if(deletedSale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Venta eliminada con exito: ", deletedSale);

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }
    }
}
