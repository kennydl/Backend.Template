using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.IntegrationTests.StartUp.Mockup
{
    public static class ServiceMockups
    {
        public static IServiceCollection AddRepositoryMockups(this IServiceCollection services)
        {
            return services;
        }
    }
}