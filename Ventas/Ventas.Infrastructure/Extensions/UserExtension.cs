

using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Models.Users;

namespace Ventas.Infrastructure.Extensions
{
    /// <summary>
    /// Metodos de extension correspondiente a User
    /// </summary>
    public static class UserExtension
    {
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                RolNombre = user.Role.nombre,
                FechaRegistro = user.fechaRegistro
            };
        }

        public async static Task<User> ToUser(this UserModel userModel, ApplicationDbContext context)
        {
            Role? rol = await context.Rol.FirstOrDefaultAsync(r => r.nombre == userModel.RolNombre);

            return new User
            {
                nombreCompleto = userModel.NombreCompleto,
                correo = userModel.Correo,
                Eliminado = userModel.Eliminado,
                idRol = rol.idRol
            };
        }


        public static async Task<List<UserModel>> ToUserModelList(this List<User> users, ApplicationDbContext context)
        {
            var roles = await context.Rol.ToDictionaryAsync(r => r.idRol, r => r.nombre);

            var list = users.Select(user => new UserModel
            {
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                RolNombre = roles.ContainsKey(user.idRol) ? roles[user.idRol] : null,
                FechaRegistro = user.fechaRegistro
            }).ToList();

            return list;
        }


        public static User FromInputToUser(this UserInputModel input)
        {
            User user = new User
            {
                nombreCompleto = input.NombreCompleto,
                correo = input.Correo,
                idRol = input.idRol,
                clave = input.clave,
                esActivo = input.esActivo,
            };

            return user;
        }

    }
}
