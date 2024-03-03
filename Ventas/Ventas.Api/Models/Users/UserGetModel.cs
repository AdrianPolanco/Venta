namespace Ventas.Api.Models.Users
{
    public class UserGetModel: UserUpdateModel
    {
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
