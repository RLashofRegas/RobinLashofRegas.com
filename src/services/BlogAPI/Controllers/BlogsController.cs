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
        private const string TileImagesFolder = "blogTileImages";

        private readonly BlogContext context;
        private readonly IOptionsMonitor<AppOptions> appOptions;
        private readonly ILogger<BlogsController> logger;

        public BlogsController(BlogContext context, IOptionsMonitor<AppOptions> appOptions, ILogger<BlogsController> logger)
        {
            this.context = context;
            this.appOptions = appOptions;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog([FromForm] PostBlogModel blogModel)
        {
            if (blogModel == null)
            {
                throw new ArgumentNullException($"{nameof(blogModel)}");
            }

            if (await this.context.Blogs.AnyAsync(b => b.Name == blogModel.Name).ConfigureAwait(true))
            {
                this.ModelState.AddModelError("Name", "A blog with that name already exists, please choose a different name.");
                return this.BadRequest(this.ModelState);
            }

            string imageBasePath = Path.Combine(this.appOptions.CurrentValue.ImagesPath, TileImagesFolder);
            if (!Directory.Exists(imageBasePath))
            {
                _ = Directory.CreateDirectory(imageBasePath);
            }

            string imagePath = Path.Combine(imageBasePath, Path.GetRandomFileName());

            this.logger.LogDebug($"Name: {blogModel.TileImage.Name}; ContentType: {blogModel.TileImage.ContentType}; Length: {blogModel.TileImage.Length}");

            using (FileStream stream = System.IO.File.Create(imagePath))
            {
                await blogModel.TileImage.CopyToAsync(stream).ConfigureAwait(true);
            }

            var blog = new Blog {
                Name = blogModel.Name,
                TileImagePath = imagePath
            };

            _ = this.context.Blogs.Add(blog);
            _ = await this.context.SaveChangesAsync().ConfigureAwait(true);

            return this.CreatedAtAction(nameof(GetBlog), new {
                id = blog.BlogId
            }, blog);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await this.context.Blogs.ToListAsync().ConfigureAwait(true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            Blog blog = await this.context.Blogs.FindAsync(id).ConfigureAwait(true);

            return blog == null ? this.NotFound() : (ActionResult<Blog>) blog;
        }
    }
}
