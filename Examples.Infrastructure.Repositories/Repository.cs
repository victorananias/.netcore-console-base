using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _table;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }
        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> list)
        {
            _table.RemoveRange(list);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllByWhereAsync(Expression<Func<T, bool>> where)
        {
            return await _table.Where(where).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _table.CountAsync();
        }

        public async Task SaveAsync(T entity)
        {
            _table.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveAsync(IEnumerable<T> list)
        {
            _table.AddRange(list);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<T> list)
        {
            _table.UpdateRange(list);
            await _dbContext.SaveChangesAsync();
        }
    }
}
