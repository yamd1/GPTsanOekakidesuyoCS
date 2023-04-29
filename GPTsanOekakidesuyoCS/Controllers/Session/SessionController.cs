using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace GPTsanOekakidesuyoCS.Controllers.session
{

    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;

        // TODO: DI
        private GetSessionService _getSessionService = new GetSessionService();

        public SessionController(
            ILogger<SessionController> logger
            // GetSessionService getSessionService
        ) {
            _logger = logger;
            // _getSessionService = getSessionService;
        }

        [HttpGet(Name = "GetSessionController")]
        public async Task<ActionResult<GetSessionResponse>> Get(int id)
        {
            return await _getSessionService.run();
        }
    }
}
