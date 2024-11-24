using BookingSystem.DAL.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace BookingSystem.DAL.Common.Extensions
{
    public static class PaginationExtension
    {
        public static IPagedList<TSource> ToPaginate<TSource>(this IQueryable<TSource> self, IPagination paging)
        {
            if (paging is null) throw new ArgumentNullException(nameof(paging));

            string
                sortExpr = paging.GetSortExpression(),
                filter = paging.GetDynamicFilterExpression();

            if (!string.IsNullOrWhiteSpace(filter))
                self = self.Where(filter);

            if (!string.IsNullOrWhiteSpace(sortExpr))
                self = self.OrderBy(sortExpr);

            int rowCount = self.Count();

            var data = self
               .Skip(paging.Skip * paging.Take)
               .Take(paging.Take)
               .ToList();

            return new PagedList<TSource>(data, rowCount);
        }
        public static IPagedList<TMappedSource> Map<TSource, TMappedSource>(this IPagedList<TSource> self, Func<TSource, TMappedSource> expr)
        {
            var mapping = self.Data.Select(expr);
            return new PagedList<TMappedSource>(mapping, self.RowCount);
        }
    }
    }
