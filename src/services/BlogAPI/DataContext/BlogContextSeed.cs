using System.Linq;
using System.Threading.Tasks;
using BlogAPI.DataContext.Models;

namespace BlogAPI.DataContext
{
    public class BlogContextSeed
    {
        public async Task SeedAsync(BlogContext context)
        {
            if (context.Blogs.Any())
            {
                return;
            }

            var recipePosts = new Post[] 
            {
                new Post { Title="Recipe 1", RawContent="# Recipe 1", ParsedContent="<h1>Recipe 1</h1>" },
                new Post { Title="Recipe 2", RawContent="# Recipe 2", ParsedContent="<h1>Recipe 2</h1>" }
            };

            var adventurePosts = new Post[] 
            {
                new Post { Title="Adventure 1", RawContent="# Adventure 1", ParsedContent="<h1>Adventure 1</h1>" },
                new Post { Title="Adventure 2", RawContent="# Adventure 2", ParsedContent="<h1>Adventure 2</h1>" }
            };

            var blogs = new Blog[]
            {
                new Blog { Name="Recipes", Posts = recipePosts },
                new Blog { Name="Adventures", Posts = adventurePosts }
            };

            await context.AddRangeAsync(blogs);

            await context.SaveChangesAsync();
        }
    }
}