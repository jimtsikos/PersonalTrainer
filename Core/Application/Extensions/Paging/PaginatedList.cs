﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Extensions.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage { get => PageIndex > 1; }
        public bool HasNextPage { get => PageIndex < TotalPages; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public static PaginatedList<T> Create(IQueryable<T> source, Pageable pageable = null)
        {
            var count = source.Count();
            var items = pageable != null ? source.Skip((pageable.Page - 1) * pageable.PageSize).Take(pageable.PageSize).ToList() : source.ToList();
            return new PaginatedList<T>(items, count, pageable.Page, pageable.PageSize);
        }
    }
}
