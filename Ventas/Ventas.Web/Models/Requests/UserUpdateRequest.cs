using System.ComponentModel.DataAnnotations;

namespace Ventas.Web.Models.Requests
{
    public class UserUpdateRequest
    {
            public int Id { get; set; } 
            [Required(ErrorMessage = "El campo NombreCompleto es obligatorio.")]
            [MaxLength(100, ErrorMessage = "El campo NombreCompleto no debe exceder los 100 caracteres.")]
            public string nombreCompleto { get; set; }

            [Required(ErrorMessage = "El campo Correo es obligatorio.")]
            [EmailAddress(ErrorMessage = "Por favor, ingresa una dirección de correo electrónico válida.")]
            [MaxLength(40, ErrorMessage = "El campo Email no debe exceder los 40 caracteres.")]
            public string correo { get; set; }

            [Required(ErrorMessage = "El campo idRol es obligatorio.")]
            public int idRol { get; set; }

            [Required(ErrorMessage = "El campo esActivo es obligatorio.")]
            public bool esActivo { get; set; }

            [Required(ErrorMessage = "El campo clave es obligatorio.")]
            [MaxLength(40, ErrorMessage = "El campo clave no debe exceder los 50 caracteres.")]
            public string clave { get; set; }
        
    }
}
