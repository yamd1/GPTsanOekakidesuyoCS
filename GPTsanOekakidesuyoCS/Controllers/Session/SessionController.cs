using Microsoft.AspNetCore.Mvc;

namespace GPTsanOekakidesuyoCS.Controllers.session
{

    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        public SessionController(ILogger<SessionController> logger) 
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSessionController")]
        public string Get(int id)
        {
            return id.ToString();
        }
    }
}
