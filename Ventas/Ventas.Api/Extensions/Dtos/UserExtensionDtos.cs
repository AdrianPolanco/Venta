
using Ventas.Api.Dtos.Base;
using Ventas.Domain.Entities;

namespace Ventas.Api.Extensions.Dtos
{
    public static class UserExtensionDtos
    {
        public static User ToUser(this BaseUserDto baseUserDto)
        {
            return new User
            {
                nombreCompleto = baseUserDto.NombreCompleto,
                correo = baseUserDto.Correo,
                idRol = baseUserDto.idRol,
                clave = baseUserDto.clave,
                esActivo = baseUserDto.esActivo,
            };
        }   
    }
}
