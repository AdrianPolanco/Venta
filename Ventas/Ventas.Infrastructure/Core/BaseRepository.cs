
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public virtual async Task<TEntity?> Update(TEntity entity, int id)
        {
            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<TEntity?> Delete(int id)
        {
            try
            {
                TEntity? entity = await this.GetEntity(id);

                if (entity == null) return null;

                _dbSet?.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                bool exists = await _dbSet.AnyAsync(filter);
                return exists;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async virtual Task<List<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                List<TEntity> foundEntity = await _dbSet.Where(filter).ToListAsync();
                return foundEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async virtual Task<List<TEntity>> GetEntities()
        {
            try
            {
                List<TEntity> entities = await _dbSet.ToListAsync();
                return entities;    
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async virtual Task<TEntity?> GetEntity(int id)
        {
            try
            {
                TEntity? entity = await _dbSet.FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
