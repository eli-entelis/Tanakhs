namespace TanakhsApi.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
