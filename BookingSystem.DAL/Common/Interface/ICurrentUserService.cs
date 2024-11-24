using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common.Interface
{

    public interface ICurrentUserService
    {
      
        string CurrentUserId { get; }
        string UserRole { get; }
        void SetCurrentUserInfo( string userId, string userRole);
    }
}

