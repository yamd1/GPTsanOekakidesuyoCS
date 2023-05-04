
public interface IPostSessionRequest { };

namespace GPTsanOekakidesuyoCS.Requests.Session
{
    public class PostSessionRequest : IPostSessionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
