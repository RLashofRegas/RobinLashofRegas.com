namespace BlogAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string RawContent { get; set; }
        public string ParsedContent { get; set; }

        public Blog Blog { get; set; }
    }
}