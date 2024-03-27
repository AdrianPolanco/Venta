

namespace Ventas.Web.Models.Responses
{
    public class UserGetResponse
    {
            public int Id { get; set; }
            public string NombreCompleto { get; set; } = null!;
            public string Correo { get; set; } = null!;
            public int idRol { get; set; }
            public string clave { get; set; } = null!;
            public bool esActivo { get; set; }
             public string Clave { get; set; }
            public DateTime fechaRegistro { get; set; }
            public DateTime? FechaMod { get; set; }
            public DateTime? FechaElimino { get; set; }
            public bool? Eliminado { get; set; }

       
    }
}
