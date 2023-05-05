namespace GPTsanOekakidesuyoCS.Apis.Interface
{
    public interface IOpenAiRawResponse
    {
        string id { get; set; }
        string _object { get; set; }
        int created { get; set; }
        string model { get; set; }
        object usage { get; set; }
        List<object> choises { get; set; }
    }
}
