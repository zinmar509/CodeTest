using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BookingSystem.BLL.Auth.DataWrappers;
using BookingSystem.DAL.DbModel;
using BookingSystem.DAL.ConfigModel;

namespace BookingSystem.BLL.Auth
{
    internal class TokenService : ITokenService
    {
        public string GenereateToken(TokenOption _options, TokenData tokenData)
        {
            Claim[] claims = GetClaims(tokenData);
          
            if (_options.TokenEncryptionKey.Length < 32)
                throw new ArgumentException("TokenEncryptionKey must be at least 32 characters long.");

            var _tokenencKey = Encoding.UTF8.GetBytes(_options.TokenEncryptionKey);
            var now = DateTime.UtcNow;

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.TokenEncryptionKey));

          

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                Subject = new ClaimsIdentity(claims),
                NotBefore = now,
                IssuedAt = UnixTimeStampToDateTime(int.Parse(claims.First(claim => claim.Type == "iat").Value)),
                Expires = now.Add(_options.Expiration),
                SigningCredentials = _options.SigningCredentials,
                EncryptingCredentials = new EncryptingCredentials(
                    new SymmetricSecurityKey(_tokenencKey),
                    SecurityAlgorithms.Aes256KW,
                    SecurityAlgorithms.Aes256CbcHmacSha512)
            };

            var handler = new JwtSecurityTokenHandler();
            string encodedJwt = handler.CreateEncodedJwt(tokenDescriptor);
            return encodedJwt;
        }

        Claim[] GetClaims(TokenData tokenData)
        {
            var claims = new Claim[] {
                new Claim (ClaimTypes.Name, tokenData.UserId),
                new Claim (ClaimTypes.Role, tokenData.Role),
                new Claim ("UserId", tokenData.UserId),
                new Claim ("LoginType", tokenData.LoginType),
                new Claim ("TicketExpireDate", tokenData.TicketExpireDate.ToString ()),
                new Claim (JwtRegisteredClaimNames.Sub, tokenData.Sub),
                new Claim (JwtRegisteredClaimNames.Jti, tokenData.Jti),
                new Claim (JwtRegisteredClaimNames.Iat, tokenData.Iat, ClaimValueTypes.Integer64)
            };
            return claims;
        }

        DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
