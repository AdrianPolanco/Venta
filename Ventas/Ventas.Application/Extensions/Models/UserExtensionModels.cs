
using Ventas.Domain.Entities;
using Ventas.Application.Models.Users;
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
                idRol = user.idRol,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaElimino = user.FechaElimino,
                FechaMod = user.FechaMod
            };
        }

        public static UserCreateModel ToCreateUserModel(this User user)
        {

            return new UserCreateModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                idRol= user.idRol,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
            };
        }

        public static UserUpdateModel ToUpdateUserModel(this User user)
        {

            return new UserUpdateModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                idRol = user.idRol,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaMod = user.FechaMod
            };
        }

        public static UserDeleteModel ToDeleteUserModel(this User user) {

            return new UserDeleteModel
            {
                Id = user.idUsuario,
                NombreCompleto = user.nombreCompleto,
                Correo = user.correo,
                Eliminado = (bool)user.Eliminado,
                fechaRegistro = user.fechaRegistro,
                esActivo = user.esActivo,
                FechaElimino = user.FechaElimino,
                FechaMod = user.FechaMod
            };
        }

        public static List<UserGetModel> ToGetUserModelList(this List<User> users)
        {

            var list = users.Select( user => new UserGetModel
                {
                    Id = user.idRol,
                    NombreCompleto = user.nombreCompleto,
                    Correo = user.correo,
                    idRol = user.idRol,
                    fechaRegistro = user.fechaRegistro,
                    FechaMod = user.FechaMod,
                    FechaElimino = user.FechaElimino,
                }
            ).ToList();

            return list;
        }

    }
}
