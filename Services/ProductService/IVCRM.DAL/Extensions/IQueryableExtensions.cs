using IVCRM.Core;
using IVCRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> source, TableParameters parameters)
        {
            var count = source.Count();
            var items = await source.Skip((parameters.PageNumber) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
            return new PagedList<T>(items, count, parameters);
        }
    }
}
