namespace Ventas.Application.Models.Users
{
    public record UserGetModel : UserUpdateModel
    {
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
