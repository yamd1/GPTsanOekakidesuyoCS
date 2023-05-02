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
        private GPTsanOekakidesuyoCSContext _context;
        private SessionRepository _sessionRepository;

        // DIを用いて初期化
        // Program.csで対象をDIコンテナに登録済み
        public GetSessionService(GPTsanOekakidesuyoCSContext context,
            SessionRepository sessionRepository
            ) 
            { 
                _context = context;
                _sessionRepository = sessionRepository;
            }

        public async Task<GetSessionResponse> run(int id) 
        {
            // TODO: Firstではなく、Messageを複数取得、レスポンスを構築するように修正
            // TODO: DB問い合わせクラスにコードを移動
            var dbResponses = await _sessionRepository.FindById(id);
                Console.WriteLine("----------  ------------");

            foreach (var i in dbResponses)
            {
                Console.WriteLine(i);
            }
            var mockSession = new Models.Session();
            //mockSession.Id = dbResponse.Session.Id;
            //mockSession.Name = dbResponse.Session.Name;

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
