
namespace Ventas.Application.Models.Base
{
    public record BaseUserModel : BaseModel
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int idRol { get; set; }
        public bool esActivo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
