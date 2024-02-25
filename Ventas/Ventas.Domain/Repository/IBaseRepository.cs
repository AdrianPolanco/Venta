
using System.Linq.Expressions;
using Ventas.Domain.Entities;

namespace Ventas.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity?> Update(TEntity entity, int id);
        Task<TEntity?> Delete(int id);
        Task<List<TEntity>> GetEntities();
        Task<TEntity?> GetEntity(int id);
        Task<List<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
