
namespace Ventas.Api.Models.Base
{
    public class BaseUserModel: BaseModel
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int idRol { get; set; }
        public string NombreRol {  get; set; }
        public bool esActivo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
