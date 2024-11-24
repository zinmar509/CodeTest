using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookingSystem.BLL.Auth.DataWrappers
{
    public class SuccessLogin
    {
        public int ExpiresIn { get; set; }
        [JsonProperty("UserID")]
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
    }
}
