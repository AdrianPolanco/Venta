
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Models
{

        //Los modelos, a diferencia de las entidades de Dominio pueden tener comportamiento y/o lógica
        public class UserModel
        {
            public string NombreCompleto { get; set; }
            public string Correo { get; set; }
            public string RolNombre { get; set; }
            public DateTime FechaRegistro { get; set; }
        }

        public static class UserMapper
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
    }
       

    }
