
using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Repositories;
using Ventas.Infrastructure.Context;

namespace Ventas.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual bool  Exits(Func<TEntity, bool> filter)
        {
            return _dbSet.Any(filter);
        }

        public virtual List<TEntity> FinAll(Func<TEntity, bool> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void  Save(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();   
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public virtual void update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _dbContext.SaveChanges();
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
