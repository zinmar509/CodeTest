using BookingSystem.BLL.Auth;
using BookingSystem.BLL.Auth.DataWrappers;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }


        [HttpPost, Route("~/api/token")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                bool authenticated = _authenticationManager.Authenticate(login, out tblAdmin loggedInAccount);
                if (!authenticated)
                    return ProcessError("Invalid username or password.");

              
                var (successLogin, access_token) = await _authenticationManager.LoginAsync(HttpContext, loggedInAccount, login.LoginType);
                var response = new LogInResponse(false, true, "Successfully Logged in.", access_token, successLogin);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ProcessError("Login failure.");
            }
        }
    }
}
