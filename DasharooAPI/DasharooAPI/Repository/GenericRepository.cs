using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using X.PagedList;

namespace DasharooAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DasharooDbContext _context;
        protected readonly DbSet<T> _db;

        public GenericRepository(DasharooDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        protected IQueryable<T> Query()
        {
            return _db;
        }

        protected IQueryable<T> Include(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes, IQueryable<T> query)
        {
            return includes != null ?
                includes(query)
                : query;
        }

        protected IQueryable<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, IQueryable<T> query)
        {
            return orderBy != null ? orderBy(query) : query;
        }

        protected IQueryable<T> Expression(Expression<Func<T, bool>> expression, IQueryable<T> query)
        {
            return expression != null ? query.Where(expression) : query;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = Query();
            query = Include(includes, query);

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = Query();

            query = Expression(expression, query);
            query = Include(includes, query);
            query = OrderBy(orderBy, query);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = Query();

            query = Include(includes, query);

            return await query.AsNoTracking()
                .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Update(entity);
        }

        public void Attach(T entity)
        {
            _db.Attach(entity);
        }
    }
}
