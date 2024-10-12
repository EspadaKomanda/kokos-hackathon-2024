using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchService.Database;
using Microsoft.EntityFrameworkCore;

namespace MatchService.Repository
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _empDBContext;
        public Repository(ApplicationContext empDBContext)
        {
            _empDBContext = empDBContext;
        }
        public async Task<bool> Add(TEntity entity)
        {
            await _empDBContext.Set<TEntity>().AddAsync(entity);
            return await _empDBContext.SaveChangesAsync()>= 0;
        }
        public async Task<bool> AddMany(IEnumerable<TEntity> entities)
        {
            await _empDBContext.Set<TEntity>().AddRangeAsync(entities);
            return await _empDBContext.SaveChangesAsync()>= 0;
        }
        public bool Delete(TEntity entity)
        {
            _empDBContext.Set<TEntity>().Remove(entity);
            return _empDBContext.SaveChanges()>= 0;
        }
        public bool DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Find(predicate);
            _empDBContext.Set<TEntity>().RemoveRange(entities);
            return _empDBContext.SaveChanges()>= 0;
        }
        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return await Get(findOptions).FirstOrDefaultAsync(predicate)!;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return Get(findOptions).Where(predicate);
        }
        public IQueryable<TEntity> GetAll(FindOptions? findOptions = null)
        {
            return Get(findOptions);
        }
        public bool Update(TEntity entity)
        {
            _empDBContext.Set<TEntity>().Update(entity);
            return _empDBContext.SaveChanges()>= 0;
        }
        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await _empDBContext.Set<TEntity>().AnyAsync(predicate);
        }
        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await _empDBContext.Set<TEntity>().CountAsync(predicate);
        }
        private DbSet<TEntity> Get(FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _empDBContext.Set<TEntity>();
            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes().AsNoTracking();
            }
            else if (findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes();
            }
            else if (findOptions.IsAsNoTracking)
            {
                entity.AsNoTracking();
            }
            return entity;
        }
    }

}