using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Template.Api.V1.HealthCheck
{
    [ApiController]
    [Route("api/v1")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        
        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [Route("status")]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.Run(() => Ok("The service is up and running."));
        }
    }
}