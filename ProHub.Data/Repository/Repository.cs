using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProHub.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
           where TEntity : class
    {
        protected readonly ProHubDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ProHubDbContext context)
        {
            this.DbContext = context;
            this.DbSet = DbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query(string sql, params object[] parameters) =>
            DbSet.FromSqlRaw(sql, parameters);

        public virtual IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy?.Invoke(query).ToList() ?? query.ToList();
        }

        public virtual IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);
            if (orderBy != null) return orderBy(query).ToList();
            return query.ToList();
        }

        public virtual IQueryable<TEntity> FindIQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TEntity> FindIQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                return await orderBy.Invoke(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<TEntity>> FindPagedAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageNum = 1, int pageSize = 10)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                return await orderBy.Invoke(query).ToPagedListAsync(pageNum, pageSize);
            return await query.ToPagedListAsync(pageNum, pageSize);
        }

        public virtual async Task<IPagedList<TEntity>> FindPagedAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false, int pageNum = 1, int pageSize = 10)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);
            if (orderBy != null)
                return await orderBy.Invoke(query).ToPagedListAsync(pageNum, pageSize);
            return await query.ToPagedListAsync(pageNum, pageSize);
        }

        public virtual IPagedList<TEntity> FindPaged(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageNum = 1, int pageSize = 10)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null
                ? orderBy.Invoke(query).ToPagedList(pageNum, pageSize)
                : query.ToPagedList(pageNum, pageSize);
        }

        public virtual IPagedList<TEntity> FindPaged(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false, int pageNum = 1, int pageSize = 10)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);

            return orderBy != null
                ? orderBy(query).ToPagedList(pageNum, pageSize)
                : query.ToPagedList(pageNum, pageSize);
        }

        public virtual TEntity FindById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return await DbSet.CountAsync(filter);
            return await DbSet.CountAsync();
        }
        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return DbSet.Count(filter);
            return DbSet.Count();
        }


        public virtual TEntity FindInclude(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null) query = include(query);
            return query.FirstOrDefault();
        }

        public virtual async Task<TEntity> FindIncludeAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null) query = include(query);
            return await query.FirstOrDefaultAsync();
        }

        public virtual TEntity FirstInclude(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault();
        }
        public virtual async Task<TEntity> FirstIncludeAsync(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
                query = query.Where(filter);
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> AllIncludeAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (include != null) query = include(query);
            return await query.ToListAsync();
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public virtual void InsertRange(params TEntity[] entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
                DbSet.Attach(entityToDelete);
            DbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
                DbSet.RemoveRange(query);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            DbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entityToUpdate)
        {
            DbSet.UpdateRange(entityToUpdate);
        }

        public bool SaveChange()
        {
            return DbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

    }
}
