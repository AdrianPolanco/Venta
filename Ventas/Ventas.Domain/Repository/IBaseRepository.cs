
using Ventas.Domain.Entities;

namespace Ventas.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
      /*  void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetEntities();
        TEntity GetEntity(int id);*/

        //Asi quedara el repositorio base luego del refactory
    }
}
