using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BookingSystem.BLL.Auth.DataWrappers
{
    public class TokenOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double TokenExpire { get; set; }
        public TimeSpan Expiration => TimeSpan.FromMinutes(TokenExpire);
        public string SecretKey { get; set; }
        public SigningCredentials SigningCredentials => new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            SecurityAlgorithms.HmacSha256);
        public Func<string, string, Task<ClaimsIdentity>> IdentityResolver { get; set; }
        public string TokenEncryptionKey { get; set; }
    }
}
