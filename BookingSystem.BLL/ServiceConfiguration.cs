using BookingSystem.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BLL
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddBusinessLogics(this IServiceCollection services)
        {
            ServiceInstaller.InstallServices(services, Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
