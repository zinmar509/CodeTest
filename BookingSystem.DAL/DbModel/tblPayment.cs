using BookingSystem.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
   
    [Table("tblPayment")]
    public class tblPayment:BookingSystemEntityBase
    {
        public tblPayment() : base("PM-")
        {

        }
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
                public DateTime PaymentDate { get; set; }
    }
}
