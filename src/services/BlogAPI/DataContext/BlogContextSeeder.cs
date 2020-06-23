using System;
using System.Linq;
using System.Threading.Tasks;

using BlogAPI.Models;

namespace BlogAPI.DataContext
{
    public static class BlogContextSeeder
    {
        public static async Task SeedAsync(BlogContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException($"{nameof(context)}");
            }

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

            var recipeBlog = new Blog {
                Name = "Recipes",
                TileImagePath = "/SeedImages/recipes-tile.jpg"
            };
            _ = recipeBlog.Posts.Concat(recipePosts);

            var adventureBlog = new Blog {
                Name = "Adventures",
                TileImagePath = "/SeedImages/adventures-tile.jpg"
            };
            _ = adventureBlog.Posts.Concat(adventurePosts);

            var blogs = new Blog[]
            {
                recipeBlog,
                adventureBlog
            };

            await context.AddRangeAsync(blogs).ConfigureAwait(true);

            _ = await context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}
