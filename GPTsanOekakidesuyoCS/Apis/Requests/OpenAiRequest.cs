using GPTsanOekakidesuyoCS.Apis.Interface;

namespace GPTsanOekakidesuyoCS.Apis.Requests
{
    public class OpenAiRequest
    {
        public string model { get; set; }
        public List<IOpenAiMessage> messages { get; set; }
        public int temperature { get; set; }
    }
}
