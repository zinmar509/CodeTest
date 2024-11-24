using BookingSystem.BLL.Interface;
using BookingSystem.Common.Attributes;
using BookingSystem.Common.Exceptions;
using BookingSystem.DAL;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Enum;
using BookingSystem.DAL.Common.Interface;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.DbModel;
using BookingSystem.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BLL.Implementation
{
    [ScopedDependency]
    public class HotelLogic : IHotelLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly IEFfRepository<tblHotel> _hotelRepo;
       

        public HotelLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepo = unitOfWork.GetRepository<tblHotel>();
        }
        public async Task<tblHotel> CreateOrUpdateAsync(HotelDTO hotel)
        {
            if (_hotelRepo.IsExist(x => x.Name == hotel.Name                   
                   && x.Status == Status.Active.ToString()
                   && x.Id != hotel.Id))
                throw new DuplicateDataException("Hotel Name");

            var editedHotel = await _hotelRepo.GetSingleAsync(x => x.Id == hotel.Id);
            if (editedHotel is not null)
            {
                editedHotel.Map(hotel);
                _hotelRepo.Update(editedHotel);
                await _unitOfWork.SaveChangesAsync();
                return editedHotel;
            }
            else
            {
                tblHotel htNew = new tblHotel();
                htNew.Map(hotel);
                await _hotelRepo.CreateAsync(htNew);
                await _unitOfWork.SaveChangesAsync();
                return htNew;
            }

        }

        public async Task DeleteAsync(string Id)
        {
            var editedActionEvent = await _hotelRepo.GetSingleAsync(x => x.Id == Id, true);
            if (editedActionEvent is not null)
            {
                editedActionEvent.Status = Status.InActive.ToString();
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<tblHotel> GetByIdAsync(string Id)
            => await _hotelRepo.GetSingleAsync(x => x.Id == Id&&x.Status==Status.Active.ToString());

        public IPagedList<tblHotel> GetPaging(IPagination pagination)
         => _hotelRepo.GetPaging(x =>  x.Status == Status.Active.ToString(), pagination);


       


    }
}
