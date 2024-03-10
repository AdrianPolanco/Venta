using System.Reflection;

namespace Ventas.Application.Dtos.Base
{
    public abstract record BaseUserDto
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int idRol { get; set; }
        public string clave { get; set; } = null!;
        public bool esActivo { get; set; }

        /// <summary>
        /// Metodo para validar que cada una de las propiedades de la instancia actual de la clase tienen algun valor valido
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Validate()
        {
            PropertyInfo[] properties = GetType().GetProperties();

            bool validation = properties.Any(p => p.GetValue(this) == null || p.GetValue(this) == "" || p.GetValue(this) == "string" || p.GetValue(this) == "0");

            return validation;
        }
    }
}
