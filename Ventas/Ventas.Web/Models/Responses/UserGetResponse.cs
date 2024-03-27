

using Ventas.Application.Models.Users;

namespace Ventas.Web.Models.Responses
{
    public class UserGetResponse
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int idRol { get; set; }
        public bool esActivo { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime? FechaMod { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool? Eliminado { get; set; }
    }

    public static class UserMapper{
        public static UserGetResponse ToUserResponse(this UserGetModel userGetModel)
        {
            return new UserGetResponse
            {
                Id = userGetModel.Id,
                NombreCompleto = userGetModel.NombreCompleto,
                Correo = userGetModel.Correo,
                idRol = userGetModel.idRol,
                fechaRegistro = userGetModel.fechaRegistro,
                FechaMod = userGetModel?.FechaMod,
                FechaElimino = userGetModel?.FechaElimino,
                Eliminado = userGetModel.Eliminado
            };
        }
    }
}
