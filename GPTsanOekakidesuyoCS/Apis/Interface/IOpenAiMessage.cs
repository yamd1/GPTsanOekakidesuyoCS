namespace GPTsanOekakidesuyoCS.Apis.Interface
{
    public interface IOpenAiMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}

