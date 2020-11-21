using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.Extensions.ServiceCollectionExtensions
{
    public static class ServiceApplicationInsight
    {
        public static IServiceCollection IncludeApplicationInsightsTelemetry(this IServiceCollection services)
        {
            return services.AddApplicationInsightsTelemetry(GetApplicationInsightsOptions());
        }
        
        private static ApplicationInsightsServiceOptions GetApplicationInsightsOptions()
        {
            // Disable custom metrics
            return new ApplicationInsightsServiceOptions()
            {
                EnableHeartbeat = false,
                EnableAppServicesHeartbeatTelemetryModule = false,
                EnableAzureInstanceMetadataTelemetryModule  = false
            };
        }
    }
}