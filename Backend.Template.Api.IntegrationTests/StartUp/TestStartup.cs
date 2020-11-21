using System.Reflection;
using Backend.Template.Api.Extensions;
using Backend.Template.Api.Extensions.ServiceCollectionExtensions;
using Backend.Template.Api.V1.HealthCheck;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.IntegrationTests.StartUp
{
    public class TestStartup
    {
        private IConfiguration Configuration { get; }
        
        public TestStartup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public  void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.ConfigureMvc();
            mvcBuilder
                .AddApplicationPart(Assembly.GetAssembly(typeof(StatusController)))
                .AddControllersAsServices();

            services
                .AddServices(Configuration);

            ConfigureMockExternalServices(services);
        }

        private static void ConfigureMockExternalServices(IServiceCollection services)
        {
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Configure(env);
            SeedDbTestData(app);
        }

        private static void SeedDbTestData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }
    }
}