using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.ConfigModel
{
   
        public class TokenData
        {
          
            public string Sub { get; set; } = "";  
            public string Jti { get; set; } = ""; 
            public string Iat { get; set; } = ""; 
            public string UserId { get; set; } = "";
            public string Role { get; set; } = "";
            public string LoginType { get; set; } = "";
            public DateTime TicketExpireDate { get; set; } = DateTime.UtcNow;
        }
    }

