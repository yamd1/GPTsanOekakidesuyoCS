using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Responses.Message;

namespace GPTsanOekakidesuyoCS.Services
{
    public class GetSessionService
    {
        public GetSessionService() { }

        public GetSessionResponse run() 
        { 
            // DB問い合わせ

            return new GetSessionResponse();
        }

        private GetSessionResponse CreateResponse()
        {
            var response = new GetSessionResponse();
            response.Id = 0;
            response.Name = "test";
            response.Messages =
         }

        private List<Models.Message> CreateMessages(List<Models.Message> messages)
        { 
            var messageList = new List<Models.Message>();
            for (int i = 0, len = messages.Count; i < len; i++)
            {
                var message = new GetMessage();
                message.Id = messages[i];
            }
        }



    }
}
