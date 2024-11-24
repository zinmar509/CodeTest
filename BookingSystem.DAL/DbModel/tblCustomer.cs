using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
   
    [Table("tblCustomer")]
    public class tblCustomer : BookingSystemEntityBase
    {
        public tblCustomer() : base("CUS-")
        {

        }
        public string Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
