using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
    [Table("tblHotel")]
    public class tblHotel:BookingSystemEntityBase
    {
        public tblHotel() : base("HTL-")
        {

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}