using Ventas.Application.Dtos.Base;

namespace Ventas.Application.Dtos.Users
{
    public record UserUpdateDto: BaseUserDto
    {
        public int Id { get; set; }
    }
}
