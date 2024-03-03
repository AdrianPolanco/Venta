namespace Ventas.Infrastructure.Core
{
    public abstract class BaseRepositoryBase1<TEntity> where TEntity : class
    {

        public virtual async Task<TEntity?> Update(TEntity entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}