
using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Api.Models.Users;
using System.Data;

namespace Ventas.Api.Extensions.Models
{
    /// <summary>
    /// Metodos de extension correspondiente a User
    /// </summary>
    public static class UserExtensionModels
    {
        public static UserGetModel ToGetUserModel(this User user)
        {
            return new UserGetModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                NombreRol = user.Role.nombre,
                idRol = user.idRol,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaElimino = user.FechaElimino,
                FechaMod = user.FechaMod
            };
        }

        public static async Task<UserCreateModel> ToCreateUserModel(this User user, ApplicationDbContext context)
        {
            var roles = await context.Rol.ToDictionaryAsync(r => r.idRol, r => r.nombre);

            return new UserCreateModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                idRol= user.idRol,
                NombreRol = roles.ContainsKey(user.idRol) ? roles[user.idRol] : null,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
            };
        }

        public static async Task<UserUpdateModel> ToUpdateUserModel(this User user, ApplicationDbContext context)
        {
            var roles = await context.Rol.ToDictionaryAsync(r => r.idRol, r => r.nombre);

            return new UserUpdateModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                idRol = user.idRol,
                NombreRol = roles.ContainsKey(user.idRol) ? roles[user.idRol] : null,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaMod = user.FechaMod
            };
        }

        public static async Task<UserDeleteModel> ToDeleteUserModel(this User user, ApplicationDbContext context) {
            var roles = await context.Rol.ToDictionaryAsync(r => r.idRol, r => r.nombre);

            return new UserDeleteModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                NombreRol = roles.ContainsKey(user.idRol) ? roles[user.idRol] : null,
                Eliminado = (bool)user.Eliminado,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaElimino = user.FechaElimino,
                FechaMod = user.FechaMod
            };
        }

        public static async Task<List<UserGetModel>> ToGetUserModelList(this List<User> users, ApplicationDbContext context)
        {
            var roles = await context.Rol.ToDictionaryAsync(r => r.idRol, r => r.nombre);

            var list = users.Select(user => new UserGetModel
            {
                Id  = user.idRol,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                NombreRol = roles.ContainsKey(user.idRol) ? roles[user.idRol] : null,
                idRol = user.idRol,
                fechaRegistro = user.fechaRegistro,
                FechaMod = user.FechaMod,
                FechaElimino = user.FechaElimino,
            }).ToList();

            return list;
        }

    }
}
