using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProHub.Domain.Repository
{
    public interface IRepository<TEntity> : IDisposable
         where TEntity : class
    {
        IQueryable<TEntity> Query(string sql, params object[] parameters);
        IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);
        IQueryable<TEntity> FindIQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> FindIQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        Task<IEnumerable<TEntity>> FindAsync(
              Expression<Func<TEntity, bool>> filter = null,
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
              string includeProperties = "");

        Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);
        Task<IPagedList<TEntity>> FindPagedAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageNum = 1, int pageSize = 10);

        Task<IPagedList<TEntity>> FindPagedAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false, int pageNum = 1, int pageSize = 10);

        IPagedList<TEntity> FindPaged(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false, int pageNum = 1, int pageSize = 10);
        IPagedList<TEntity> FindPaged(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageNum = 1, int pageSize = 10);

        TEntity FindInclude(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<IEnumerable<TEntity>> AllIncludeAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> FindIncludeAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null);
        TEntity FirstInclude(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "");
        Task<TEntity> FirstIncludeAsync(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "");
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void InsertRange(params TEntity[] entities);
        void InsertRange(IEnumerable<TEntity> entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entityToUpdate);
        bool SaveChange();
        Task<bool> SaveChangeAsync();

    }
}
