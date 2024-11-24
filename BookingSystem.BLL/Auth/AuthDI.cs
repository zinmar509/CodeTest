using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.BLL.Auth
{
    public static class AuthDI
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
           
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            return services;
        }
    }
}
