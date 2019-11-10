using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }
    }
}