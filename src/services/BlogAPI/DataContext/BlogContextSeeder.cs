using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;

namespace BlogAPI.DataContext
{
  public class BlogContextSeeder
  {
    public BlogContextSeeder()
    {
    }

    public async Task SeedAsync(BlogContext context)
    {
      if (context.Blogs.Any())
      {
        return;
      }

      Post[] recipePosts = new Post[]
      {
                new Post { Title="Recipe 1", RawContent="# Recipe 1", ParsedContent="<h1>Recipe 1</h1>" },
                new Post { Title="Recipe 2", RawContent="# Recipe 2", ParsedContent="<h1>Recipe 2</h1>" }
      };

      Post[] adventurePosts = new Post[]
      {
                new Post { Title="Adventure 1", RawContent="# Adventure 1", ParsedContent="<h1>Adventure 1</h1>" },
                new Post { Title="Adventure 2", RawContent="# Adventure 2", ParsedContent="<h1>Adventure 2</h1>" }
      };

      Blog[] blogs = new Blog[]
      {
                new Blog { Name="Recipes", TileImagePath = "/SeedImages/recipes-tile.jpg", Posts = recipePosts },
                new Blog { Name="Adventures", TileImagePath = "/SeedImages/adventures-tile.jpg", Posts = adventurePosts }
      };

      await context.AddRangeAsync(blogs);

      _ = await context.SaveChangesAsync();
    }
  }
}
