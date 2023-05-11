using GPTsanOekakidesuyoCS.Apis.Interface;

namespace GPTsanOekakidesuyoCS.Apis.Responses
{
    public class OpenAiMessage : IOpenAiMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
