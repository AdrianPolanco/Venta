using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Extensions;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models.Sales;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.Api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private ILogger<ISaleRepository> _logger;

        public SalesController(ISaleRepository saleRepository, ILogger<ISaleRepository> logger)
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
                List<SaleModel> salesModels = sales.ToSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        // GET: api/<ValuesController>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                Sale? sale = await _saleRepository.GetEntity(id);

                if (sale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Venta encontrada: ", sale);
                return Ok(sale);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("/dates")]
        public async Task<IActionResult> GetByDate()
        {
            try
            {
                List<Sale> sales = await _saleRepository.GetByDate();
                List<SaleModel> salesModels = sales.ToSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("/totals")]
        public async Task<IActionResult> GetByTotal()
        {
            try
            {
                List<Sale> sales = await _saleRepository.GetByTotal();
                List<SaleModel> salesModels = sales.ToSalesModels();

                _logger.LogInformation("Ventas encontradas: ", salesModels);
                return Ok(salesModels);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleModel saleModel)
        {
            try
            {
                Sale sale = saleModel.ToSale();
                Sale savedSale = await _saleRepository.Create(sale);
                _logger.LogInformation("Nueva venta guardada", savedSale);

                return CreatedAtAction(nameof(GetById), new { id = sale.idVenta}, sale);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult>Update([FromRoute] int id, [FromBody] SaleModel saleModel)
        {
            try
            {
                Sale sale = saleModel.ToSale();
                Sale? updatedSale = await _saleRepository.Update(sale, id);

                if(updatedSale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Venta actualizada con exito: ", updatedSale);

                return Ok(updatedSale);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
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

                _logger.LogError("Error obteniendo las ventas", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }
    }
}
