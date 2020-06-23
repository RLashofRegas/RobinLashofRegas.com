using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogAPI.Models
{
    public class Blog
    {
        public Blog()
        {
            Posts = new Collection<Post>();
        }

        public int BlogId { get; set; }
        public string Name { get; set; }
        public string TileImagePath { get; set; }

        public ICollection<Post> Posts { get; private set; }
    }
}
