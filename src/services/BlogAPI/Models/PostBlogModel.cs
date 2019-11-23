using Microsoft.AspNetCore.Http;

namespace BlogAPI.Models
{
    public class PostBlogModel
    {
        public string Name { get; set; }
        public IFormFile TileImage { get; set; }
    }
}