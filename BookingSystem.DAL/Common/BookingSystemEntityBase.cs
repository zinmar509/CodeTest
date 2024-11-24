using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common
{
    public abstract class BookingSystemEntityBase
    {
        public BookingSystemEntityBase()
        {
            Id = $"{Guid.NewGuid()}";
        }
        public BookingSystemEntityBase(string prefix)
        {
            Id = $"{prefix}-{Guid.NewGuid()}";
        }
        string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _id = value;
            }
        }
       
        [JsonIgnore]
        public string Status { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public virtual void Map(object dto)
        {
            var props = this.GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            var dtoProps = dto.GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in props)
            {
                foreach (var dtoProp in dtoProps)
                {
                    if (prop.Name == dtoProp.Name)
                    {
                        var val = dtoProp.GetValue(dto);
                        if (prop.Name == "Id" && String.IsNullOrEmpty(val?.ToString()))
                            prop.SetValue(this, this.Id); 
                        else
                        prop.SetValue(this, dtoProp.GetValue(dto));
                    }
                }
            }
        }
    }
}
