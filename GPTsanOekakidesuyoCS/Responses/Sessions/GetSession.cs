namespace GPTsanOekakidesuyoCS.Responses.Sessions
{
    public class GetSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
