using GPTsanOekakidesuyoCS.Responses.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace GPTsanOekakidesuyoCS.Controllers.Session
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        // DIに用いるフィールドを定義
        private readonly ILogger<SessionsController> _logger;
        private IGetSessionsService _getSessionsService;

        // DIによる初期化
        // Program.csで対象をDIコンテナに登録済み
        public SessionsController(
            ILogger<SessionsController> logger,
            IGetSessionsService getSessionsService
        )
        {
            _logger = logger;
            _getSessionsService = getSessionsService;
        }

        [HttpGet]
        public async Task<ActionResult<GetSessionsResponse>> Get()
        {
            return await _getSessionsService.run();
        }
    }
}
