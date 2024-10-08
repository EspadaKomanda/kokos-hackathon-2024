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
        public bool Add(TEntity entity)
        {
            _empDBContext.Set<TEntity>().Add(entity);
            return _empDBContext.SaveChanges()>= 0;
        }
        public bool AddMany(IEnumerable<TEntity> entities)
        {
            _empDBContext.Set<TEntity>().AddRange(entities);
            return _empDBContext.SaveChanges()>= 0;
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
        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return Get(findOptions).FirstOrDefault(predicate)!;
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
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _empDBContext.Set<TEntity>().Any(predicate);
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _empDBContext.Set<TEntity>().Count(predicate);
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