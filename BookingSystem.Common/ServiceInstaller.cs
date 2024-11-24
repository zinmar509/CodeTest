using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Scrutor;
using BookingSystem.Common.Attributes;

namespace BookingSystem.Common
{
    public static class ServiceInstaller
    {
        public static void InstallServices(IServiceCollection services, Assembly assembly)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblies(assembly)
                        .AddClasses(cls => cls.WithAttribute<ScopedDependencyAttribute>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()

                        .AddClasses(cls => cls.WithAttribute<TransientDependencyAttribute>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()

                        .AddClasses(cls => cls.WithAttribute<SingletonDependencyAttribute>())
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime()

                        .AddClasses(cls => cls.WithAttribute<SelfScopedDependencyAttribute>())
                        .AsSelf()
                        .WithScopedLifetime()

                        .AddClasses(cls => cls.WithAttribute<SelfTransientDependencyAttribute>())
                        .AsSelf()
                        .WithTransientLifetime()

                        .AddClasses(cls => cls.WithAttribute<SelfSingletonDependencyAttribute>())
                        .AsSelf()
                        .WithSingletonLifetime();
            });
        }
    }
}
