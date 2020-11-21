using System.Linq;
using System.Reflection;
using AutoMapper;
using Backend.Template.Api.Filters;
using Backend.Template.Api.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions.ServiceCollectionExtensions
{
    public static class ServiceStartUp
    {
        public static IMvcBuilder ConfigureMvc(this IServiceCollection services)
        {
            return services
                .AddControllers(config =>
                {
                    config.Filters.Add(typeof(ExceptionFilter));
                })
                .IncludeJsonOptions();
        }
        
        public static IServiceCollection ConfigureConnections(this IServiceCollection services, IConfiguration config)
        {
            return services
                .IncludeHttpClients(config);
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddAutoMapper(new[]
                {
                    typeof(LogErrorMapper),
                }.Select(Assembly.GetAssembly))
                .AddMemoryCache()
                .IncludeServices();
            // .IncludeApplicationInsightsTelemetry();
        }
    }
}