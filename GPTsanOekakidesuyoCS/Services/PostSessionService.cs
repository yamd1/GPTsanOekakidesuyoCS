using Microsoft.AspNetCore.Mvc;
using GPTsanOekakidesuyoCS.Responses.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
                var openAiRequest = CreateRequestWithWessionOpenAi(session, userMessage);
            }

            return new PostSessionResponse();
        }

        private bool IsExistsId(IPostSessionRequest _postSessionRequest)
        {
            return _postSessionRequest.Id != 0;
        }

        private IUserMessage CreateUserMessage(IPostSessionRequest _postSessionRequest)
        { 
            var userMessage = new UserMessage();
            userMessage.role = "user";
            userMessage.content = _postSessionRequest.Message;
            return userMessage;
        }

        private 

    }

}
