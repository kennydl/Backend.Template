using System.Net;
using System.Threading.Tasks;
using Backend.Template.Api.IntegrationTests.StartUp;
using NUnit.Framework;

namespace Backend.Template.Api.IntegrationTests.Controllers
{
    public class StatusControllerTests
    {
        private TestWebApplicationFactory WebFactory { get; } = SetUpFixture.WebFactory;
        
        [Test]
        public async Task Get_endpoint_status_expects_http_status_200_ok()
        {
            var client = WebFactory.CreateClient();
            var response = await client.GetAsync("/status");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}