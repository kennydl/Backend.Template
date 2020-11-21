using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions.ServiceCollectionExtensions
{
    public static class ServiceHttpClient
    {
        public static IServiceCollection IncludeHttpClients(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        private static IServiceCollection AddClient<TClient, TImplementation>(
            this IServiceCollection services,
            string baseUrl) where TClient : class
            where TImplementation : class, TClient
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                services.AddHttpClient<TClient, TImplementation>();
            }
            else
            {
                services.AddHttpClient<TClient, TImplementation>(client =>
                    {
                        client.BaseAddress = new Uri(baseUrl);
                    }
                );
            }
            return services;
        }
    }
}