using BookingSystem.DAL.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common
{
    public class PagedList<T> : IPagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int RowCount { get; set; }
        public PagedList()
        {

        }
        public PagedList(IEnumerable<T> data, int rowCount)
        {
            Data = data;
            RowCount = rowCount;
        }
    }
}
