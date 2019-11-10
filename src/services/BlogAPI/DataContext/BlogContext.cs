using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.DataContext.EntityConfigurations;
using Microsoft.Extensions.Logging;

namespace BlogAPI.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options, ILoggerFactory loggerFactory)
            : base(options)
        { 
            LoggerFactory = loggerFactory;
        }

        private ILoggerFactory LoggerFactory { get; }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogEntityConfiguration());

            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        }
    }
}