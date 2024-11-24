using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
    
    [Table("tblBooking")]
    public class tblBooking:BookingSystemEntityBase
    {
        public tblBooking() : base("BK-")
        {

        }
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string HotelId { get; set; }
        public int NoOfRoom { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
    }
}
