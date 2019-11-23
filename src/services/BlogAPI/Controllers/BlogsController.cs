using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BlogAPI.DataContext;
using BlogAPI.Models;
using BlogAPI.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private const string TILE_IMAGES_FOLDER = "blogTileImages";

        private readonly BlogContext _context;
        private readonly IOptionsMonitor<AppOptions> _appOptions;
        
        public BlogsController(BlogContext context, IOptionsMonitor<AppOptions> appOptions)
        {
            _context = context;
            _appOptions = appOptions;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(PostBlogModel blogModel)
        {
            if(await _context.Blogs.AnyAsync(b => b.Name == blogModel.Name))
            {
                ModelState.AddModelError("Name", "A blog with that name already exists, please choose a different name.");
                return BadRequest(ModelState);
            }

            string imageBasePath = Path.Combine(_appOptions.CurrentValue.ImagesPath, TILE_IMAGES_FOLDER);
            if(!Directory.Exists(imageBasePath))
            {
                Directory.CreateDirectory(imageBasePath);
            }

            string imagePath = Path.Combine(imageBasePath, Path.GetRandomFileName());

            using(var stream = System.IO.File.Create(imagePath))
            {
                await blogModel.TileImage.CopyToAsync(stream);
            }

            Blog blog = new Blog
                {
                    Name = blogModel.Name,
                    TileImagePath = imagePath
                };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if(blog == null)
            {
                return NotFound();
            }

            return blog;
        }
    }
}