using Microsoft.AspNetCore.Mvc;
using GPTsanOekakidesuyoCS.Responses.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GPTsanOekakidesuyoCS.Apis.Requests;
using GPTsanOekakidesuyoCS.Apis.Interface;
using GPTsanOekakidesuyoCS.Apis.Responses;

public interface IPostSessionService 
{
    Task<PostSessionResponse> Run(IPostSessionRequest _postSessionRequest);
}

public interface IUserMessage
{ 
    string role { get; set; }
    string content { get; set; }
}

public class UserMessage : IUserMessage
{ 
    public string role { get; set; }
    public string content { get; set; }
}

namespace GPTsanOekakidesuyoCS.Services
{
    public class PostSessionService
    {
        public ISessionRepository _sessionRepository { get; set; }

        public PostSessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<PostSessionResponse> Run(IPostSessionRequest _postSessionRequest)
        {
            ActionResult<Models.Session> session;

            if(_postSessionRequest.Id != null)
            {
                session = await _sessionRepository.FindById(_postSessionRequest.Id);                
                if(session == null) 
                {
                    throw new Exception("指定されたIDは存在しません。");
                }


                var userMessage = CreateUserMessage(_postSessionRequest);
                var openAiRequest = CreateRequestWithSessionOpenAi(session, userMessage);
            }

            return new PostSessionResponse();
        }

        private bool IsExistsId(IPostSessionRequest _postSessionRequest)
        {
            return _postSessionRequest.Id != 0;
        }

        private IOpenAiMessage CreateUserMessage(IPostSessionRequest _postSessionRequest)
        { 
            var userMessage = new OpenAiMessage();
            userMessage.role = "user";
            userMessage.content = _postSessionRequest.Message;
            return userMessage;
        }

        private OpenAiRequest CreateRequestWithSessionOpenAi(ActionResult<Models.Session> session, IOpenAiMessage userMessage)
        {
            var messages = new List<IOpenAiMessage>();
            foreach(var message in session.Value.Messages)
            {
                var m = new OpenAiMessage();
                m.role = message.Role;
                m.content = message.Content;
                messages.Add(m);
            }
            messages.Add(userMessage);
            
            var openAiRequest = new OpenAiRequest();
            openAiRequest.messages = messages;
            openAiRequest.model = Environment.GetEnvironmentVariable("OPEN_AI_MODEL");
            openAiRequest.temperature = 0.7;

            return openAiRequest;
        }

    }

}
