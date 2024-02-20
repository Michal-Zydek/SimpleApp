using Microsoft.EntityFrameworkCore.Query;
using SimpleApp.Database.Configuration.BaseEntity;
using System.Linq.Expressions;

namespace SimpleApp.Database.Configuration.BaseRepository
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class, IDataEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            int? skip = null,
            int? take = null);

        public TKey Insert(TEntity entity);
        public bool Delete(TKey id);
        public bool Update(TEntity entity);
    }
}
