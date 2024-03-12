using Microsoft.AspNetCore.Mvc;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;
using Ventas.Application.Dtos.Users;
using Ventas.Infrastructure.ObjectQueries;
using Ventas.Application.Contracts.Services;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Core;
using Ventas.Application.Messages;

namespace Ventas.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerService<IUserRepository> _logger;

        public UserController(IUserService userService, ILoggerService<IUserRepository> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ServiceResult result = await _userService.GetAll();

            if (!result.Success)
            {
                _logger.LogError($"Error al buscar usuarios: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Usuarios encontrados: ", result);
            return Ok(result);
        }
      
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            ServiceResult result = await _userService.GetById(id);
            if (!result.Success && result.Message.Equals(StatusMessages.GET_NOTFOUND))
            {
                _logger.LogError("Usuario no encontrado: ", result);
                return NotFound(result);
            }

            if (!result.Success && result.Message.Equals(StatusMessages.GET_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al buscar el usuario {id}: ", result);
                return StatusCode(500, result);
            }
            _logger.LogInformation($"Usuario encontrado con el id {id}: ", result);
            return Ok(result);
        }

        [HttpGet("dates")]
        public async Task<IActionResult> GetByDate([FromQuery] SortQuery query)
        {
            ServiceResult result = await _userService.GetByDate(query.IsDescending);

            if (!result.Success)
            {
                _logger.LogError($"Ocurrio en error en el servidor al buscar los usuarios: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Usuarios encontrados y ordenados por fecha: ", result);
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetByRole([FromQuery] SortQuery query)
        {
            ServiceResult result = await _userService.GetByRole(query.IsDescending);

            if (!result.Success)
            {
                _logger.LogError($"Ocurrio en error en el servidor al buscar los usuarios: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Usuarios encontrados y ordenados por rol: ", result);
            return Ok(result);
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetByName([FromQuery] SortQuery query)
        {
            ServiceResult result = await _userService.GetByName(query.IsDescending);

            if (!result.Success)
            {
                _logger.LogError($"Ocurrio en error en el servidor al buscar los usuarios: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Usuarios encontrados y ordenados por nombre: ", result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
        {
            ServiceResult result = await _userService.Create(userDto);
            if (!result.Success && result.Message.Equals(StatusMessages.POST_INVALID))
            {
                _logger.LogError("Usuario no creado por campos inválidos: ", result);
                return BadRequest(result);
            }

            if (!result.Success && result.Message.Equals(StatusMessages.POST_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al intentar crear el usuario: ", result);
                return StatusCode(500, result);
            }
            _logger.LogInformation($"Usuario creado con exito: ", result);
            return Ok(result);
        }

       
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userDto)
        {
            ServiceResult result = await _userService.Update(userDto);
            if (!result.Success && result.Message.Equals(StatusMessages.PUT_INVALID))
            {
                _logger.LogError("Usuario no actualizado por campos inválidos o por ser inexistente: ", result);
                return BadRequest(result);
            }

            if (!result.Success && !result.Message.Equals(StatusMessages.PUT_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al intentar crear el usuario: ", result);
                return StatusCode(500, result);
            }
            _logger.LogInformation($"Usuario creado con exito: ", result);
            return Ok(result);
        }
 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            ServiceResult result = await _userService.Delete(id);

            if (!result.Success && result.Message.Equals(StatusMessages.DELETE_NOTFOUND))
            {
                _logger.LogError("Usuario a eliminar no encontrado: ", result);
                return NotFound(result);
            }

            if (!result.Success && !result.Message.Equals(StatusMessages.DELETE_FAILURE))
            {
                _logger.LogError($"Ocurrio en error en el servidor al intentar eliminar el usuario {id}: ", result);
                return StatusCode(500, result);
            }

            _logger.LogInformation("Usuario eliminado con exito: ", result);

            return Ok(result);

        }
    }
}
