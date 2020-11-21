using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Template.Api.IntegrationTests.StartUp
{
    public class TestWebApplicationFactory : WebApplicationFactory<TestStartup> 
    {
        private readonly SqliteConnection _connection;
        private readonly IConfigurationRoot _configuration;

        public TestWebApplicationFactory()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", false)
                .Build();
            _connection = new SqliteConnection(_configuration.GetConnectionString("Sql"));
            _connection.Open();
        }

        protected override IWebHostBuilder CreateWebHostBuilder() =>
            WebHost
                .CreateDefaultBuilder()
                .UseEnvironment("Development")
                .ConfigureServices(AddSqlite)
                .ConfigureAppConfiguration(configBuilder =>
                {
                    configBuilder.AddJsonFile("testsettings.json", false);
                })
                .UseStartup<TestStartup>();

        private static void AddSqlite(IServiceCollection services)
        {
            services
                .AddEntityFrameworkSqlite();
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
        }
    }
}