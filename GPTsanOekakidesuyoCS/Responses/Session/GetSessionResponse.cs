using GPTsanOekakidesuyoCS.Responses.Message;

namespace GPTsanOekakidesuyoCS.Responses.Session
{
    public class GetSessionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetMessage> Messages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
