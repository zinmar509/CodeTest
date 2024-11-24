using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BLL.Auth.DataWrappers
{
    public record LogInResponse(bool RequiredOTP, bool Success, string Message, string Access_token, SuccessLogin Data);
  

}
