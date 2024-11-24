using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DAL.Common.Interface;
using Newtonsoft.Json;

namespace BookingSystem.DAL.Common
{
    public class Pagination : IPagination
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
        public IEnumerable<Sorting> Sort { get; set; }
        public Filter Filter { get; set; }
        public virtual string GetSortExpression()
        {
            if (Sort is null || !Sort.Any())
                return null;

            List<string> sortFields = new();
            sortFields.AddRange(Sort.Select(x => string.IsNullOrWhiteSpace(x.Field) ? "" : $"[{x.Field}] {x.Dir}"));
            return string.Join(", ", sortFields);
        }

        public Func<IEnumerable<InnerFilter>, string> OnFiltering { get; set; }
        public virtual string GetFilterExpression()
        {
            if (Filter?.Filters == null)
                return string.Empty;

            if (OnFiltering is not null)
                return OnFiltering.Invoke(Filter.Filters);

            List<string> filtersFields = new();
           

            foreach (var filter in Filter?.Filters)
            {
                if (!string.IsNullOrEmpty(filter.Value))
                {
                    
                }
            }
            return string.Join(" and ", filtersFields);
        }
        /// <summary>
        /// Pagination expression for Dynamic Linq 
        /// </summary>
        /// <returns></returns>
        public string GetDynamicFilterExpression()
        {
            if (Filter?.Filters == null)
                return string.Empty;
            List<string> filtersFields = new();
            filtersFields.AddRange(Filter.Filters.Select(x => $"{x.Field} == \"{x.Value}\""));
            return string.Join(" and ", filtersFields);
        }
    }
    public record Sorting(string Dir, string Field);
    public record Filter(IEnumerable<InnerFilter> Filters);
    public record InnerFilter(string Field, string Value, string Type);


}
