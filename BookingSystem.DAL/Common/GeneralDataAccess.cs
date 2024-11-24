using BookingSystem.DAL.ConfigModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common
{
    public static class   GeneralDataAccess
    {
        public static TokenData GetTokenData(JwtSecurityToken tokenS)
        {
            var obj = new TokenData();
            try
            {
                obj.UserId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
                obj.Role = tokenS.Claims.First(claim => claim.Type == "role").Value;
                obj.LoginType = tokenS.Claims.First(claim => claim.Type == "LoginType").Value;
                 obj.Sub = tokenS.Claims.First(claim => claim.Type == "sub").Value;
                string TicketExpire = tokenS.Claims.First(claim => claim.Type == "TicketExpireDate").Value;
                DateTime TicketExpireDate = DateTime.Parse(TicketExpire);
                obj.TicketExpireDate = TicketExpireDate;
            }
            catch (Exception ex)
            {
                //add log
            }
            return obj;
        }


        public static Claim[] GetClaims(TokenData obj)
        {
            var claims = new Claim[] {
                new Claim (ClaimTypes.Name, obj.UserId),
                new Claim (ClaimTypes.Role, obj.Role),
                new Claim ("UserId", obj.UserId),
                new Claim ("LoginType", obj.LoginType),
                new Claim ("TicketExpireDate", obj.TicketExpireDate.ToString ()),
                new Claim (JwtRegisteredClaimNames.Sub, obj.Sub),
                new Claim (JwtRegisteredClaimNames.Jti, obj.Jti),
                new Claim (JwtRegisteredClaimNames.Iat, obj.Iat, ClaimValueTypes.Integer64)
            };
            return claims;
        }

    }
}
