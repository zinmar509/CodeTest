using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookingSystem.BLL.Auth.DataWrappers;
using BookingSystem.DAL.DbModel;
using BookingSystem.DAL.ConfigModel;

namespace BookingSystem.BLL.Auth
{
    public interface IAuthenticationManager
    {
        bool Authenticate(LoginModel loginData, out tblAdmin loggedinAccount);
        Task<string> GenereateTokenAsync(tblAdmin loggedinAccount, string logInType);
        Task<(SuccessLogin SuccessLogin, string Token)> LoginAsync(HttpContext context, tblAdmin loggedinAccount, string logInType);
    }
}
