using Backend.Template.Api.IntegrationTests.StartUp;
using NUnit.Framework;

namespace Backend.Template.Api.IntegrationTests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        public static TestWebApplicationFactory WebFactory { get; private set; }
        
        [OneTimeSetUp]
        public void SetUp()
        {
            WebFactory = new TestWebApplicationFactory();
        }
    }
}