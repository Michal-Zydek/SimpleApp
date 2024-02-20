using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SimpleApp.Database.Configuration.BaseEntity;
using SimpleApp.Database.Models;
using System.Linq.Expressions;

namespace SimpleApp.Database.Configuration.BaseRepository
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IDataEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly SimpleAppContext context;
        public Repository(SimpleAppContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true,
        int? skip = null,
        int? take = null)
        {
            return GetQuerableData(predicate, orderBy, include, disableTracking, skip, take);
        }

        public virtual IQueryable<TEntity> GetQuerableData(
             Expression<Func<TEntity, bool>> predicate = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
             bool disableTracking = true,
             int? skip = null,
             int? take = null)
        {
            IQueryable<TEntity> source = context.Set<TEntity>();
            if (disableTracking)
            {
                source = source.AsNoTracking();
            }
            if (include != null)
            {
                source = include(source);
            }
            if (predicate != null)
            {
                source = source.Where(predicate);
            }
            if (skip != null)
            {
                source = source.Skip((int)skip);
            }
            if (take != null)
            {
                source = source.Take((int)take);
            }

            return source;
        }

        public virtual TKey Insert(TEntity entity)
        {
            context.Add(entity);
            var result = context.SaveChanges();
            return result > 0 ? entity.Id : default;
        }
        public virtual bool Delete(TKey id)
        {
            var entity = context.Set<TEntity>().Find(id);
            context.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public virtual bool Update(TEntity entity)
        {
            if (entity.Id != null)
            {
                context.Update(entity);
                return context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
