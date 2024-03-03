using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IMenuRolRepository
    {
        void Create(MenuRol menuRol);
        void Update(MenuRol menuRol);
        void Remove(MenuRol menuRol);

        List<MenuRol> GetMenuRol();

        MenuRol GetMenuRol(int idMenuRol);
    }
}
