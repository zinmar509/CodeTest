using BookingSystem.DAL.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        string  _currentUserId, _userRole;
        public string CurrentUserId => _currentUserId ?? string.Empty;
        public string UserRole => _userRole;

        public void SetCurrentUserInfo( string userId, string userRole)
        {
            _currentUserId = userId;
            _userRole = userRole;
        }
    }
}
