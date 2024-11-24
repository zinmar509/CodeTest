using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
    [Table("tblBookingRoom")]
    public class tblBookingRoom : BookingSystemEntityBase
    {
        public tblBookingRoom() : base("")
        {

        }
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string BookingId { get; set; }
    }
}
