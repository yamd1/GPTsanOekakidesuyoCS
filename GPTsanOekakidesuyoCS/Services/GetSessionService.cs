using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Responses.Message;
using GPTsanOekakidesuyoCS.Data;

public interface IGetSessionService
{
    Task<GetSessionResponse> run();
}

namespace GPTsanOekakidesuyoCS.Services
{
    public class GetSessionService : IGetSessionService
    {

        private GPTsanOekakidesuyoCSContext _context;
        public GetSessionService(GPTsanOekakidesuyoCSContext context)
        { 
            _context = context;
        }

        public async Task<GetSessionResponse> run() 
        {
            // TODO: DB問い合わせ
            var dbResponse = await _context.Session.FindAsync(1);
            Console.WriteLine(dbResponse);

            // DB返却のモック
            var mockSession = new Models.Session();
            mockSession.Id = 1;
            mockSession.Name = "test";

            var mockMessages = new List<Models.Message>();
            var mockMessage = new Models.Message();
            mockMessage.Id = 1;
            mockMessage.Role = "user";
            mockMessage.Content = "test";
            mockMessages.Add(mockMessage);

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
