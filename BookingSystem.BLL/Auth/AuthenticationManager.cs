using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using BookingSystem.DAL;
using BookingSystem.DAL.Repositories.Interface;
using BookingSystem.DAL.DbModel;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.Common.Enum;
using BookingSystem.BLL.Auth.DataWrappers;
using Microsoft.Extensions.Configuration;

namespace BookingSystem.BLL.Auth
{
    internal class AuthenticationManager : IAuthenticationManager
    {
        private readonly IEFfRepository<tblAdmin> _adminrepo;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly TokenOption _tokenOption;

        public AuthenticationManager(IEFfRepository<tblAdmin> adminRepo,
            IConfiguration configuration,
            ITokenService tokenService)
        {
            _adminrepo = adminRepo;
            _configuration = configuration;
            _tokenService = tokenService;
            _tokenOption = configuration.GetSection("TokenAuthentication").Get<TokenOption>();
        }
        public bool Authenticate(LoginModel loginData, out tblAdmin loggedinAccount)
        {
            

            loggedinAccount = _adminrepo.GetSingle(x => x.AdminUserName == loginData.username && x.Status == Status.Active.ToString());               

            if (loggedinAccount is null)
                return false;

       
            bool result = true; // Add Password validation method                 
            return result;
        }
        public async Task<(SuccessLogin SuccessLogin, string Token)> LoginAsync(HttpContext context,
            tblAdmin loggedinAccount,
            string logInType)
        {
            string sameSiteModeValue = _configuration.GetSection("SameSiteMode").Value;
            var _sameSiteMode = (SameSiteMode)Enum.Parse(typeof(SameSiteMode), sameSiteModeValue);

            var access_token = await GenereateTokenAsync(loggedinAccount, logInType);

            context.Response.Cookies.Append(
                    "Access-Token",
                    access_token,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = _sameSiteMode
                    });

       
            var successLogin = new SuccessLogin
            {
                ExpiresIn = (int)_tokenOption.Expiration.TotalSeconds,
                UserId = loggedinAccount.Id,
                DisplayName = loggedinAccount.AdminUserName,
                FullName = loggedinAccount.AdminName,
            };

            return (successLogin, access_token);
        }
        public async Task<string> GenereateTokenAsync(tblAdmin loggedinAccount, string logInType)
        {
            var now = DateTime.UtcNow;
            var _tokenData = new TokenData();
            _tokenData.Sub = loggedinAccount.AdminUserName;
            _tokenData.Jti = Guid.NewGuid().ToString();
            _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
            _tokenData.UserId = loggedinAccount.Id;
            _tokenData.LoginType = "Admin";
            _tokenData.TicketExpireDate = now.Add(_tokenOption.Expiration);
            _tokenData.Role = logInType;
            var token = _tokenService.GenereateToken(_tokenOption, _tokenData);
            return token;
        }
       
      
       

    }
}
