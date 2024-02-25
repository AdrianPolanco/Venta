using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Extensions;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IUserRepository> _logger;
        private readonly ApplicationDbContext _context;

        public UserController(IUserRepository userRepository, ILogger<IUserRepository> logger, ApplicationDbContext context)
        {
            _userRepository = userRepository;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<User> sales = await _userRepository.GetEntities();
                List<UserModel> result = await sales.ToUserModelList(_context);

                _logger.LogInformation("Ventas encontradas: ", result);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }
      
        // GET: api/<ValuesController>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                User? user = await _userRepository.GetEntity(id);

                if (user == null) return NotFound($"Usuario no encontrado: Usuario con el id {id} no existente.");

                UserModel userModel = user.ToUserModel();

                _logger.LogInformation("Usuario encontrado: ", userModel);
                return Ok(userModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        /*[HttpGet("/dates")]
        public async Task<IActionResult> GetByDate()
        {
            try
            {
                List<Sale> sales = await _userRepository.GetByDate();

                _logger.LogInformation("Ventas encontradas: ", sales);
                return Ok(sales);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("/totals")]
        public async Task<IActionResult> GetByTotal()
        {
            try
            {
                List<Sale> sales = await _userRepository.GetByTotal();

                _logger.LogInformation("Ventas encontradas: ", sales);
                return Ok(sales);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserInputModel userModel)
        {
            try
            {
                User user = userModel.FromInputToUser();
                User savedUser = await _userRepository.Create(user);
                _logger.LogInformation("Nuevo usuario guardado: ", savedUser);

                return CreatedAtAction(nameof(GetById), new { id = savedUser.idUsuario }, savedUser);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

        /*
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SaleModel saleModel)
        {
            try
            {
                Sale sale = new Sale { numeroDocumento = saleModel.numeroDocumento, tipoPago = saleModel.tipoPago, total = saleModel.total };
                Sale? updatedSale = await _userRepository.Update(sale, id);

                if (updatedSale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Venta actualizada", updatedSale);

                return Ok(updatedSale);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                Sale? deletedSale = await _userRepository.Delete(id);

                if (deletedSale == null) return NotFound($"Venta no encontrada: Venta con el id {id} no existente.");

                _logger.LogInformation("Nueva venta guardada", deletedSale);

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }*/
    }
}
