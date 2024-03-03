using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class RolRepository : IRolRepository
    {
        public RolRepository(VentasContext context)
        {
            
        }
        public void Create(Rol rol)
        {
            throw new NotImplementedException();
        }

        public List<Rol> GetRol()
        {
            throw new NotImplementedException();
        }

        public Rol GetRol(int idRol)
        {
            throw new NotImplementedException();
        }

        public void Remove(Rol rol)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
