namespace Ventas.Infrastructure.Models.Users
{

    //Los modelos, a diferencia de las entidades de Dominio pueden tener comportamiento y/o lógica

    /// <summary>
    /// Modelo creado principalmente para devolver los datos al usuario
    /// </summary>
    public class UserModel
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string RolNombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Eliminado { get; set; }
    }
}
