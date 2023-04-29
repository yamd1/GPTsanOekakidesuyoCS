using Microsoft.AspNetCore.Mvc;


namespace GPTsanOekakidesuyoCS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;
        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHelloController")]
        public string Get() 
        {
            return "hello";
        }
    }
}
