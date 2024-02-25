using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Infrastructure.Models
{
    public class UserInputModel
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int idRol { get; set; }
        public string clave { get; set; } = null!;
        public bool esActivo { get; set; }
    }
}
