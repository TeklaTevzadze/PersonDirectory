using PersonDirectory.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Extensions
{
    public static class PagingExtension
    {
        public static async Task<PagedData<T>> ToPagedData<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await Task.Run(() => query.Count());
            var list = await Task.Run(() => query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
            var data = new PagedData<T>()
            {
                Data = list,
                TotalItemCount = count,
                Page = pageNumber,
                Offset = pageSize,
                PageCount = count % pageSize == 0 ? count / pageSize : count / pageSize + 1
            };
            return data;
        }
        public static async Task<PagedData<T>> ToPagedData<T>(this ICollection<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await Task.Run(() => query.Count());
            var list = await Task.Run(() => query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
            var data = new PagedData<T>()
            {
                Data = list,
                TotalItemCount = count,
                Page = pageNumber,
                Offset = pageSize,
                PageCount = count % pageSize == 0 ? count / pageSize : count / pageSize + 1
            };
            return data;
        }
    }
}
