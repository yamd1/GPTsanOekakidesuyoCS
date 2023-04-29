namespace GPTsanOekakidesuyoCS.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public int SessionsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
