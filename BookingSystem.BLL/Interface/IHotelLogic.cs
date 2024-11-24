using BookingSystem.DAL;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Interface;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BLL.Interface
{
    public interface IHotelLogic
    {
        Task<tblHotel> CreateOrUpdateAsync(HotelDTO hotel);
        Task DeleteAsync(string Id);
        Task<tblHotel> GetByIdAsync(string Id);
        IPagedList<tblHotel> GetPaging(IPagination pagination);
    }
}
