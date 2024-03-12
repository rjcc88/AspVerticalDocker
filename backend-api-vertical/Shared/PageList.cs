using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Shared
{
    public class PageList<T>
    {
        private PageList(List<T> items, int? page, int? pageSize, int totalCount, bool pagination)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            Pagination = pagination;
        }

        private PageList(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
        public List<T> Items { get; }
        public int? Page { get; } = 1;
        public int? PageSize { get; } = 30;
        public int? TotalCount { get; }
        public bool Pagination { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize, bool pagination)
        {
            if (!pagination)
            {
                int totalCount = await query.CountAsync();
                var items = await query.ToListAsync();
                return new PageList<T>(items, totalCount);
            }
            else
            {
                int totalCount = await query.CountAsync();
                var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                return new PageList<T>(items, page, pageSize, totalCount, pagination);

            }

        }
    }
}