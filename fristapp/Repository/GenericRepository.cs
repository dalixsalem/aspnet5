using fristapp.data;
using fristapp.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace fristapp.Repository
{
    public class GenericRepository<T> : IGenericIRepository<T> where T : class

    {
        private  readonly DataBaseContext _dataBaseContext;
        private readonly  DbSet<T> _db;

        public GenericRepository(DataBaseContext context)
        {
            _dataBaseContext = context;
            _db = _dataBaseContext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);

        }

        public void DeleteRange(IEnumerable<T> entites)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public Task<IList<T1>> GetALL<T1>(Expression<Func<T1, bool>> expression = default, Func<IQueryable<T1>, IOrderedQueryable<T1>> orderBy = default, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entites)
        {

            await _db.AddRangeAsync(entites);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _dataBaseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
