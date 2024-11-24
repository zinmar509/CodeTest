using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common.Interface
{
    public interface IPagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int RowCount { get; set; }
    }
}
