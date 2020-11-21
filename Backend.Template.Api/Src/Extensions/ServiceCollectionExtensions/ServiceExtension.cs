using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Backend.Template.Api.Presenters;
using Backend.Template.Core.Attributes;
using Backend.Template.Core.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions.ServiceCollectionExtensions
{
    public static class ServiceExtension
    {       
        public static IServiceCollection IncludeServices(this IServiceCollection services)
        {
            var assemblyTypes = new [] {
                typeof(ScopedServiceAttribute),
                typeof(Presenter)
            };

            var implementations = assemblyTypes
                .SelectMany(t => 
                    Assembly
                        .GetAssembly(t)?
                        .GetTypes()
                        .Where(
                            type => type.IsClass &&
                                    type.IsAbstract == false
                        ) 
                    ?? throw new DefaultException("No assemblies found")
                );

            services.ScanForServices(implementations);
            return services;
        }

        private static IServiceCollection ScanForServices(this IServiceCollection services, IEnumerable<Type> implementations)
        {
            foreach(Type implementation in implementations)
            {
                var serviceTypes = implementation.GetInterfaces();
                if (implementation.GetCustomAttribute<ScopedServiceAttribute>() != null)
                {
                    services.AddScopedServices(serviceTypes, implementation);
                }
                else if (implementation.GetCustomAttribute<SingletonServiceAttribute>() != null)
                {
                    services.AddSingletonServices(serviceTypes, implementation);
                }
            }
            return services;
        }

        private static void AddScopedServices(
            this IServiceCollection services,
            Type[] serviceTypes,
            Type implementation)
        {
            if (serviceTypes.Any() == false)
            {
                services.AddScoped(implementation);
                return;
            }

            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType, implementation);
            }
        }

        private static void AddSingletonServices(
            this IServiceCollection services,
            Type[] serviceTypes,
            Type implementation)
        {
            if (serviceTypes.Any() == false)
            {
                services.AddSingleton(implementation);
                return;
            }

            foreach (var serviceType in serviceTypes)
            {
                services.AddSingleton(serviceType, implementation);
            }
        }
    }
}
