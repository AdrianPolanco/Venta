
namespace Ventas.Infrastructure.Models
{

        //Los modelos, a diferencia de las entidades de Dominio pueden tener comportamiento y/o lógica
        public class UserModel
        {
            public string NombreCompleto { get; set; }
            public string Correo { get; set; }
            public string RolNombre { get; set; }
            public DateTime FechaRegistro { get; set; }
            public bool? Eliminado { get; set; }
    }
    }
