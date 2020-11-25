using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllByWhereAsync(Expression<Func<T, bool>> where);
        Task SaveAsync(T entity);
        Task SaveAsync(IEnumerable<T> list);
        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> list);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IEnumerable<T> list);
        Task<int> GetCountAsync();
    }
}
