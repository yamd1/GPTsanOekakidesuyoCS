using Microsoft.AspNetCore.Mvc;


namespace GPTsanOekakidesuyoCS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;
        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHealthCheckController")]
        public string Get() 
        {
            return "HealthCheck Ok";
        }
    }
}
