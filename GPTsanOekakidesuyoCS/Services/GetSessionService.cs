using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Responses.Message;
using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Repository;

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
            // TODO: Firstではなく、Messageを複数取得、レスポンスを構築するように修正
            // TODO: DB問い合わせクラスにコードを移動
            var dbResponses = await _sessionRepository.FindById(id);

            //var dbResponses =  _context.Session
            //        .Join(_context.Message,
            //            b => b.Id,
            //            m => m.SessionsId,
            //            (joinSession, joinMessage) => new 
            //            {
            //                Session = joinSession,
            //                Message = joinMessage
            //            }
            //        )
            //        .Where( e => e.Session.Id.Equals(id));
            foreach (var dbResponse in dbResponses)
            {
                dbResponse.Session.Id;
            }
            var mockSession = new Models.Session();
            //mockSession.Id = dbResponses.
            //mockSession.Name = dbResponses.Session.Name;

            var mockMessages = new List<Models.Message>();
            var mockMessage = new Models.Message();
            //mockMessage.Id = dbResponse.Message.Id;
            //mockMessage.Role = dbResponse.Message.Role;
            //mockMessage.Content = dbResponse.Message.Content;
            //mockMessages.Add(mockMessage);

            return CreateResponse(mockSession, mockMessages);
        }

        private GetSessionResponse CreateResponse(Models.Session session, List<Models.Message> massages)
        {
            var response = new GetSessionResponse();
            response.Id = session.Id;
            response.Name = session.Name;
            response.Messages = CreateMessages(massages);
            response.CreatedAt = session.CreatedAt;
            response.UpdatedAt = session.UpdatedAt;

            return response;
         }

        private List<GetMessage> CreateMessages(List<Models.Message> messages)
        { 
            var messageList = new List<GetMessage>();
            for (int i = 0, len = messages.Count; i < len; i++)
            {
                var message = new GetMessage();
                message.Id = messages[i].Id;
                message.Role = messages[i].Role;
                message.Content = messages[i].Content;
                messageList.Add(message);
            }
            return messageList;
        }
    }
}
