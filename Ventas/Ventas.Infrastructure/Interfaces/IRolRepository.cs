
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IRolRepository
    {
        void Create(Rol rol);
        void Update(Rol rol);
        void Remove(Rol rol);

        List<Rol> GetRol();

        Rol GetRol(int idRol);

    }
}
