using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingSystem.DAL.ConfigModel
{

    public abstract class PagingBase
    {
        [JsonIgnore]
        public int RecordCount { get; set; }
    }
    public interface IPageList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int RowCount { get; set; }
    }
    public class PageList<T> : IPageList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int RowCount { get; set; }
        public PageList(IEnumerable<T> data, int rowCount)
        {
            Data = data;
            RowCount = rowCount;
        }
    }
    public interface IPaginatedModel
    {
        int Skip { get; set; }
        int Take { get; set; }
        IEnumerable<Sorting> Sort { get; set; }
        Filter Filter { get; set; }
        string GetFilterExpression();
        string GetSortExpression();
        string GetDynamicFilterExpression();
    }

    public class PaginatedModel : IPaginatedModel
    {
        public string showId { get; set; }
        public string reportId { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
        public IEnumerable<Sorting> Sort { get; set; }
        public Filter Filter { get; set; }

        public Func<string> SortImp;
        public Func<string> FilterImp;
        public virtual string GetSortExpression()
        {
            if (Sort is null || Sort.Count() == 0)
                return null;

            if (SortImp is not null)
                return SortImp();

            List<string> sortFields = new();
            sortFields.AddRange(Sort.Select(x => string.IsNullOrWhiteSpace(x.Field) ? "" : $"[{x.Field}] {x.Dir}"));
            return string.Join(", ", sortFields);
        }
        public virtual string GetFilterExpression()
        {
            if (Filter?.Filters == null)
                return string.Empty;
            if (FilterImp is not null)
                return FilterImp();

            List<string> filtersFields = new();
            filtersFields.AddRange(Filter.Filters.Select(x => $"{x.Field} like '%{x.Value}%'"));
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
