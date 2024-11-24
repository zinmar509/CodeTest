using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{

    [Table("tblAdmin")]
    public class tblAdmin : BookingSystemEntityBase
    {
        public tblAdmin() : base("ADMIN-")
        {

        }
        public string Id { get; set; }

        public string Salutation { get; set; }

        public string AdminName { get; set; }

        public string AdminUserName { get; set; }

        public string AdminEmail { get; set; }

        public string AdminMobile { get; set; }
        public string AdminPassword { get; set; }
        public string AdminRole { get; set; } 
        public string EncryptPassword { get; set; }
      
    }
}
