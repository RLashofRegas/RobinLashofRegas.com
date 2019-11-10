using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.DataContext.EntityTypeConfigurations;

namespace BlogAPI.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogEntityConfiguration());

            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        }
    }
}