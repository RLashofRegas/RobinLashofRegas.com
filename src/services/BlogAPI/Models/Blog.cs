using System.Collections.Generic;

namespace BlogAPI.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string TileImagePath { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}