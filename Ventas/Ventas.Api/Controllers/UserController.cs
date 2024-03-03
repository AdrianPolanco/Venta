using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;
using Ventas.Api.Models.Users;
using Ventas.Api.Extensions.Models;
using Ventas.Api.Dtos.Users;
using Ventas.Api.Extensions.Dtos;
using Ventas.Infrastructure.ObjectQueries;

namespace Ventas.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService<IUserRepository> _logger;
        private readonly ApplicationDbContext _context;

        public UserController(IUserRepository userRepository, ILoggerService<IUserRepository> logger, ApplicationDbContext context)
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
                List<UserGetModel> result = await sales.ToGetUserModelList(_context);

                _logger.LogInformation($"Usuarios encontrados: ", result);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios: ", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }
      
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                User? user = await _userRepository.GetEntity(id);

                if (user == null) return NotFound($"Usuario no encontrado: Usuario con el id {id} no existente.");

                UserGetModel userModel = user.ToGetUserModel();

                _logger.LogInformation("Usuario encontrado: ", userModel);
                return Ok(userModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios: ", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("dates")]
        public async Task<IActionResult> GetByDate([FromQuery] SortQuery query)
        {
            try
            {
                List<User> users = await _userRepository.GetByDate(query.IsDescending);
                List<UserGetModel> result = await users.ToGetUserModelList(_context);

                _logger.LogInformation("Usuarios agrupados por fecha: ", result);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios: ", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetByRole([FromQuery] SortQuery query)
        {
            try
            {
                List<User> users = await _userRepository.GetByRole(query.IsDescending);
                List<UserGetModel> result = await users.ToGetUserModelList(_context);

                _logger.LogInformation("Usuarios agrupados por roles: ", result);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios: ", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetByName([FromQuery] SortQuery query)
        {
            try
            {
                List<User> users = await _userRepository.GetByName(query.IsDescending);
                List<UserGetModel> result = await users.ToGetUserModelList(_context);
                _logger.LogInformation("Usuarios agrupados por nombres: ", result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error obteniendo los usuarios: ", ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
        {
            try
            {
                if (userDto.Validate()) return BadRequest("Todas las propiedades deben tener valores válidos.");
                User user = userDto.ToUser();
                User savedUser = await _userRepository.Create(user);
                _logger.LogInformation("Nuevo usuario guardado: ", savedUser);

                UserCreateModel userModel = await savedUser.ToCreateUserModel(_context);

                return CreatedAtAction(nameof(GetById), new { id = savedUser.idUsuario }, userModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }

       
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userDto)
        {
            try
            {
                if (userDto.Validate()) return BadRequest("Todas las propiedades deben tener valores válidos.");
                User user = userDto.ToUser();
                User? updatedUser = await _userRepository.Update(user, userDto.Id);

                if (updatedUser == null) return NotFound($"Usuario no encontrado: Usuario con el id {userDto.Id} no existente.");

                _logger.LogInformation("Usuario actualizado: ", updatedUser);

                UserUpdateModel userUpdateModel = await updatedUser.ToUpdateUserModel(_context);

                return Ok(userUpdateModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }
 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                User? deletedUser = await _userRepository.Delete(id);

                if (deletedUser == null) return NotFound($"Usuario no encontrado o ya eliminado: Usuario con el id {id} no existe o ya ha sido eliminado.");

                UserDeleteModel userDeleteModel = await deletedUser.ToDeleteUserModel(_context);

                _logger.LogInformation("Usuario eliminado: ", userDeleteModel);

                return Ok(userDeleteModel);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error obteniendo los usuarios", ex);
                return StatusCode(500, "Ocurrió un error en el servidor");
            }

        }
    }
}
