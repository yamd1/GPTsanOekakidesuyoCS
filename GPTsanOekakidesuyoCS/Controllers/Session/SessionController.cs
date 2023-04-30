using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GPTsanOekakidesuyoCS.Data;
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
        private readonly GPTsanOekakidesuyoCSContext _context;
        private IGetSessionService _getSessionService;

        public SessionController(
            ILogger<SessionController> logger,
            GPTsanOekakidesuyoCSContext context,
            IGetSessionService getSessionService
        ) {
            _logger = logger;
            _context = context;
            _getSessionService = getSessionService;
        }

        [HttpGet(Name = "GetSessionController")]
        public async Task<ActionResult<GetSessionResponse>> Get(int id)
        {
            return await _getSessionService.run();
        }
    }
}
