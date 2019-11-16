using System.Collections.Generic;
using System.Threading.Tasks;
using BlogAPI.DataContext;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogContext _context;
        
        public BlogsController(BlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs(long id)
        {
            return await _context.Blogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(long id)
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