using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common.Interface
{
    public interface IPagination
    {
        int Skip { get; set; }
        int Take { get; set; }
        IEnumerable<Sorting> Sort { get; set; }
        Filter Filter { get; set; }

        string GetDynamicFilterExpression();
        string GetFilterExpression();
        string GetSortExpression();
        Func<IEnumerable<InnerFilter>, string> OnFiltering { get; set; }
    }
}
