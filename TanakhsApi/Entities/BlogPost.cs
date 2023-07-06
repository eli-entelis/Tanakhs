namespace TanakhsApi.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public User Author { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public DateTime PublicationDate { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
