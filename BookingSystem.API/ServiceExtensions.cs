
using BookingSystem.BLL;
using BookingSystem.BLL.Auth;
using BookingSystem.DAL;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BookingSystem.API
{
    public static class ServiceExtensions    
    {
        public static void ConfigurServies(this IServiceCollection services)
        {
            services.AddAuth();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
             services.AddBusinessLogics();
             services.AddDataAccess();
            
        }
    }
}
