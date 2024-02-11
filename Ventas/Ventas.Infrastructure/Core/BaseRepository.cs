
using Ventas.Domain.Repositories;

namespace Ventas.Infrastructure.Core
{
    internal class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: class
    {
    }
}
