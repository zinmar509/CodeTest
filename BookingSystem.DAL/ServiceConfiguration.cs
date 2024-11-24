using BookingSystem.Common;
using BookingSystem.DAL.Repositories.Implementation;
using BookingSystem.DAL.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEFfRepository<>), typeof(EfRepository<>));
            ServiceInstaller.InstallServices(services, Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
