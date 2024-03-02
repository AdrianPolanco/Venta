
using Ventas.Domain.Repository;

namespace Ventas.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class    
    {

    }
}
