using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

    [Table("tblRoom")]
    public class tblRoom : BookingSystemEntityBase
    {
        public tblRoom() : base("RM-")
        {

        }
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string RoomNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RoomType RoomType { get; set; }
        public int? Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RoomStatus RoomStatus { get; set; }
    }
}
