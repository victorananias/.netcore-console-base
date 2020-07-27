using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public async static Task<DataSet<T>> PaginateAsync<T>(this IQueryable<T> queriable, int perPage, int currentPage = 1)
        {
            var total = await queriable.CountAsync<T>();
            var lastPage = (int)Math.Ceiling((double)total / perPage);

            if (currentPage < 1)
            {
                currentPage = 1;
            }

            queriable = queriable
                .Skip(perPage * (currentPage - 1))
                .Take(perPage);

            var list = await queriable.ToListAsync<T>();

            return new DataSet<T>
            {
                CurrentPage = currentPage,
                List = list,
                LastPage = lastPage,
                Total = total,
            };
        }
    }

    public class DataSet<T>
    {
        public int CurrentPage { get; set; }
        public IEnumerable<T> List { get; set; }
        public int LastPage { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
    }
}
