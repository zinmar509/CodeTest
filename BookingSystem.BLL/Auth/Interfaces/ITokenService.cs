using BookingSystem.BLL.Auth.DataWrappers;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.DbModel;

namespace BookingSystem.BLL.Auth
{
    public interface ITokenService
    {
        string GenereateToken(TokenOption _options, TokenData tokenData);
    }
}
