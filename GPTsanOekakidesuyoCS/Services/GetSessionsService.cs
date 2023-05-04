using Microsoft.AspNetCore.Mvc;
using GPTsanOekakidesuyoCS.Responses.Sessions;

public interface IGetSessionsService 
{
    Task<GetSessionsResponse> run();
}

namespace GPTsanOekakidesuyoCS.Services
{
    public class GetSessionsService : IGetSessionsService
    {

        // DI対象フィールドを定義
        private ISessionRepository _sessionRepository;

        // DIを用いて初期化
        // Program.csで対象をDIコンテナに登録済み
        public GetSessionsService(ISessionRepository sessionRepository) 
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<GetSessionsResponse> run() 
        {
            var dbResponse = await _sessionRepository.FindAll();
            return CreateResponse(dbResponse);
        }

        private GetSessionsResponse CreateResponse(ActionResult<List<Models.Session>> dbResponse)
        {
            var response = new GetSessionsResponse();
            response.GetSessions = CreateGetSessions(dbResponse);
            return response;
        }

        private List<GetSession> CreateGetSessions(ActionResult<List<Models.Session>> dbResponse)
        { 
            var getSessionsList = new List<GetSession>();
            foreach(var session in dbResponse.Value)
            {
                var getSession = new GetSession();
                getSession.Id = session.Id;
                getSession.Name = session.Name;
                getSessionsList.Add(getSession);
            }
            return getSessionsList;
        }
    }
}
