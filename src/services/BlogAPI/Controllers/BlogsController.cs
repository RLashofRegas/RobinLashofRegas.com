using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using BlogAPI.DataContext;
using BlogAPI.Models;
using BlogAPI.Options;

namespace BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private const string TILE_IMAGES_FOLDER = "blogTileImages";

        private readonly BlogContext _context;
        private readonly IOptionsMonitor<AppOptions> _appOptions;
        private readonly ILogger<BlogsController> _logger;

        public BlogsController(BlogContext context, IOptionsMonitor<AppOptions> appOptions, ILogger<BlogsController> logger)
        {
            _context = context;
            _appOptions = appOptions;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog([FromForm] PostBlogModel blogModel)
        {
            if (blogModel == null)
            {
                throw new ArgumentNullException($"{nameof(blogModel)}");
            }

            if (await _context.Blogs.AnyAsync(b => b.Name == blogModel.Name).ConfigureAwait(true))
            {
                ModelState.AddModelError("Name", "A blog with that name already exists, please choose a different name.");
                return BadRequest(ModelState);
            }

            string imageBasePath = Path.Combine(_appOptions.CurrentValue.ImagesPath, TILE_IMAGES_FOLDER);
            if (!Directory.Exists(imageBasePath))
            {
                _ = Directory.CreateDirectory(imageBasePath);
            }

            string imagePath = Path.Combine(imageBasePath, Path.GetRandomFileName());

            _logger.LogDebug($"Name: {blogModel.TileImage.Name}; ContentType: {blogModel.TileImage.ContentType}; Length: {blogModel.TileImage.Length}");

            using (FileStream stream = System.IO.File.Create(imagePath))
            {
                await blogModel.TileImage.CopyToAsync(stream).ConfigureAwait(true);
            }

            var blog = new Blog {
                Name = blogModel.Name,
                TileImagePath = imagePath
            };

            _ = _context.Blogs.Add(blog);
            _ = await _context.SaveChangesAsync().ConfigureAwait(true);

            return CreatedAtAction(nameof(GetBlog), new {
                id = blog.BlogId
            }, blog);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync().ConfigureAwait(true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            Blog blog = await _context.Blogs.FindAsync(id).ConfigureAwait(true);

            return blog == null ? NotFound() : (ActionResult<Blog>) blog;
        }
    }
}
