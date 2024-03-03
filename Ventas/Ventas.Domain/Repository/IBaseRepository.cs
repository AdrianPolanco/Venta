
using Ventas.Domain.Entities;

namespace Ventas.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        TEntity GetEntity (int id );

        List<TEntity> GetEntities();

        List<TEntity> FinAll(Func<TEntity, bool> filter);

        bool Exits(Func<TEntity, bool> filter);

        void Save(TEntity entity);

        void update (TEntity entity);

    }
}
