using Ventas.Application.Models.Base;

namespace Ventas.Application.Models.Users
{

    //Los modelos, a diferencia de las entidades de Dominio pueden tener comportamiento y/o lógica

    /// <summary>
    /// Modelo creado principalmente para devolver los datos al usuario
    /// </summary>
    public record UserUpdateModel : BaseUserModel
    {
        public DateTime? FechaMod { get; set; }

    }
}
