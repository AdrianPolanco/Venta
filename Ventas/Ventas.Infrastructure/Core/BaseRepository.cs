

using Ventas.Domain.Repositories;

namespace Ventas.Infrastructure.Core
{
    public class BaseRepository <TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
