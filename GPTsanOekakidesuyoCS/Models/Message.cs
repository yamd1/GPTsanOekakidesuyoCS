namespace GPTsanOekakidesuyoCS.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
