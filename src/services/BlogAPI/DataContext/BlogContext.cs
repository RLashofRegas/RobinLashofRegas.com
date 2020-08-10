using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.DataContext.EntityConfigurations;
using Microsoft.Extensions.Logging;
using System;

namespace BlogAPI.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            this.LoggerFactory = loggerFactory;
        }

        private ILoggerFactory LoggerFactory { get; }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(optionsBuilder)}");
            }

            _ = optionsBuilder.UseLoggerFactory(this.LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(modelBuilder)}");
            }

            _ = modelBuilder
                .ApplyConfiguration(new BlogEntityConfiguration())
                .ApplyConfiguration(new PostEntityConfiguration());
        }
    }
}
