using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Responses.Message;
using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Repository;
using Microsoft.AspNetCore.Mvc;

public interface IGetSessionService
{
    Task<GetSessionResponse> run(int id);
}

namespace GPTsanOekakidesuyoCS.Services
{
    /**
     * ビジネスロジック
     */
    public class GetSessionService : IGetSessionService
    {
        // DI対象フィールドを定義
        private ISessionRepository _sessionRepository;
        private GPTsanOekakidesuyoCSContext _context;

        // DIを用いて初期化
        // Program.csで対象をDIコンテナに登録済み
        public GetSessionService(ISessionRepository sessionRepository, GPTsanOekakidesuyoCSContext context) 
        {
            _sessionRepository = sessionRepository;
            _context = context;
        }

        public async Task<GetSessionResponse> run(int id) 
        {
            var dbResponse = await _sessionRepository.FindById(id);
            return await CreateResponse(dbResponse);
        }

        private async Task<GetSessionResponse> CreateResponse(ActionResult<Models.Session> dbResponse)
        {
            var response = new GetSessionResponse();
            response.Id = dbResponse.Value.Id;
            response.Name = dbResponse.Value.Name;
            response.Messages = await CreateMessages(dbResponse);
            response.CreatedAt = dbResponse.Value.CreatedAt;
            response.UpdatedAt = dbResponse.Value.UpdatedAt;

            return response;
         }

        private async Task<List<GetMessage>> CreateMessages(ActionResult<Models.Session> dbResponse)
        { 
            var getMessageList = new List<GetMessage>();
            Console.WriteLine(dbResponse.Value.Messages);
            foreach(var message in dbResponse.Value.Messages)
            {
                Console.WriteLine(message);
                var getMessage = new GetMessage();
                getMessage.Id = message.Id;
                getMessage.Role = message.Role;
                getMessage.Content = message.Content;
                getMessageList.Add(getMessage);
            }
            return getMessageList;
        }
    }
}
