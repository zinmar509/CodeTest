using BookingSystem.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.ConfigModel
{
    [SelfScopedDependency]
    public class ShowUserInfo
    {
        public string UserId { get; set; }
        public string UserRole { get; set; }
    }
}
