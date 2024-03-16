using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Sales;
using Ventas.Infrastructure.ObjectQueries;
using Ventas.Application.Core;
using Ventas.Application.Messages;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Contracts.Services;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ILoggerService<ISaleRepository> _logger;
        private ISaleService<SaleCreateDto, SaleUpdateDto> _saleService;

        public SalesController(ILoggerService<ISaleRepository> logger, ISaleService<SaleCreateDto, SaleUpdateDto> saleService)
        {
            _logger = logger;
            _saleService = saleService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                ServiceResult result = await _saleService.GetAll();

                if (!result.Success)
                {
                    _logger.LogError($"Error al buscar ventas: ", result);
                    return StatusCode(500, result);
                }

                _logger.LogInformation("Ventas encontradas: ", result);
                return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

                ServiceResult result = await _saleService.GetById(id);
                if (!result.Success && result.Message.Equals(StatusMessages.GET_NOTFOUND))
                {
                    _logger.LogError("Venta no encontrada: ", result);
                    return NotFound(result);
                }

                if (!result.Success && !result.Message.Equals(StatusMessages.GET_NOTFOUND)) {
                    _logger.LogError($"Ocurrio en error en el servidor al buscar venta {id}: ", result);
                    return StatusCode(500, result);
                } 
                _logger.LogInformation($"Venta encontrada con el id {id}: ", result);
                return Ok(result);

        }

        [HttpGet("dates")]
        public async Task<IActionResult> GetByDate([FromQuery] SortQuery query)
        {
            ServiceResult result = await _saleService.GetByDate(query.IsDescending);

            if (!result.Success)
            {
                _logger.LogError($"Ocurrio en error en el servidor al buscar las ventas: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Ventas encontradas y ordenadas por fecha: ", result);
                return Ok(result);
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetByTotal([FromQuery] SortQuery query)
        {

                ServiceResult result = await _saleService.GetByTotal(query.IsDescending); ;

                if (!result.Success)
                {
                    _logger.LogError($"Ocurrio en error en el servidor al buscar las ventas: ", result);
                    return StatusCode(500, result);
                }

                _logger.LogInformation("Ventas encontradas y ordenadas por total: ", result);
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleCreateDto saleDto)
        {
            ServiceResult result = await _saleService.Create(saleDto);
            if (!result.Success && result.Message.Equals(StatusMessages.POST_INVALID))
            {
                _logger.LogError("Venta no creada por campos inválidos: ", result);
                return BadRequest(result);
            }

            if (!result.Success && result.Message.Equals(StatusMessages.POST_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al intentar crear la venta: ", result);
                return StatusCode(500, result);
            }
            _logger.LogInformation($"Venta creada con exito: ", result);
            return Ok(result);
        }

       [HttpPut]
        public async Task<IActionResult>Update([FromBody] SaleUpdateDto saleDto)
        {
            ServiceResult result = await _saleService.Update(saleDto);
            if (!result.Success && result.Message.Equals(StatusMessages.PUT_INVALID))
            {
                _logger.LogError("Venta no actualizada por campos inválidos o por ser inexistente: ", result);
                return BadRequest(result);
            }

            if (!result.Success && !result.Message.Equals(StatusMessages.PUT_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al crear la venta: ", result);
                return StatusCode(500, result);
            }
            _logger.LogInformation($"Venta creada con exito: ", result);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
                ServiceResult result = await _saleService.Delete(id);

                if (!result.Success && result.Message.Equals(StatusMessages.DELETE_NOTFOUND))
                {
                    _logger.LogError("Venta a eliminar no encontrada: ", result);
                    return NotFound(result);
                }

                if (!result.Success && !result.Message.Equals(StatusMessages.DELETE_FAILURE))
                {
                    _logger.LogError($"Ocurrio en error en el servidor al intentar eliminar la venta {id}: ", result);
                    return StatusCode(500, result);
                }

                _logger.LogInformation("Venta eliminada con exito: ", result);

                return Ok(result);
        }
    }
}
