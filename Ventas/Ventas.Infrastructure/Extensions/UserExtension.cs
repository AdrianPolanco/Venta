

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


        public static async Task<List<UserModel>> ToUserModelList(this List<User> users, ApplicationDbContext context)
        {
            IEnumerable<Task<UserModel>> tasks = users.Select(async user => {
                Role? rol = await context.Rol.FirstOrDefaultAsync(r => r.idRol == user.idRol);

                return new UserModel
                {
                    NombreCompleto = user.nombreCompleto,
                    Correo = user.correo,
                    RolNombre = rol.nombre,
                    FechaRegistro = user.fechaRegistro
                };
            });

            UserModel[] results = await Task.WhenAll(tasks);
            List<UserModel> list = results.ToList();

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
