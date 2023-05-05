
public interface IPostSessionRequest 
{
    int Id { get; set; }
    string Name { get; set; }
    string Message { get; set; }
};

namespace GPTsanOekakidesuyoCS.Requests.Session
{
    public class PostSessionRequest : IPostSessionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
