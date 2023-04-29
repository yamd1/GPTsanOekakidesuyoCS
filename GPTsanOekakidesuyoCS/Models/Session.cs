namespace GPTsanOekakidesuyoCS.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
