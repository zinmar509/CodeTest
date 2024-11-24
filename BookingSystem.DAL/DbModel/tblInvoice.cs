using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingSystem.DAL.DbModel
{
   
    [Table("tblInvoice")]
    public class tblInvoice : BookingSystemEntityBase
    {
        public tblInvoice() : base("INV-")
        {

        }
        public string Id { get; set; }
        public string InvoiceNo { get; set; }
        public string BookingId { get; set; }
        public decimal InvoiceAmount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
