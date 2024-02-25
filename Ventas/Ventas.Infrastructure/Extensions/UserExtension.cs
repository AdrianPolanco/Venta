

using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extensions
{
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

        public static List<UserModel> ToUserModelList(this List<User> users)
        {
            List<UserModel> list = users.Select(user => new UserModel
            {
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                RolNombre = user.Role.nombre,
                FechaRegistro = user.fechaRegistro
            }).ToList();

            return list;
        }

    }
}
