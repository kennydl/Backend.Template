using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions.ServiceCollectionExtensions
{
    public static class ServiceOption
    {
        private static IServiceCollection AddOption<T>(
            this IServiceCollection services,
            IConfiguration config,
            string key) where T : class
        {
            services.Configure<T>(config.GetOptionSection(key));
            return services;
        }
        
        private static IConfigurationSection GetOptionSection(this IConfiguration config, string optionKey)
        {
            return config.GetSection($"Options:{optionKey}");
        }
    }
}