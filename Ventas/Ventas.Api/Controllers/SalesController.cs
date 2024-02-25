using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

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

                _logger.LogInformation("Ventas encontradas: ", sales);
                return Ok(sales);
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

                _logger.LogInformation("Ventas encontradas: ", sales);
                return Ok(sales);
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

                _logger.LogInformation("Ventas encontradas: ", sales);
                return Ok(sales);
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
                Sale sale = new Sale { numeroDocumento = saleModel.numeroDocumento, tipoPago = saleModel.tipoPago, total = saleModel.total };
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
                Sale sale = new Sale { numeroDocumento = saleModel.numeroDocumento, tipoPago = saleModel.tipoPago, total = saleModel.total };
                Sale? updatedSale = await _saleRepository.Update(sale, id);

                if(updatedSale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Venta actualizada", updatedSale);

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

                _logger.LogInformation("Nueva venta guardada", deletedSale);

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
