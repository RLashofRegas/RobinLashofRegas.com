using System;
using System.Collections.Generic;
using System.Linq;
using BlogAPI.DataContext;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException($"{nameof(post)}");
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await _context.Posts.FindAsync(id).ConfigureAwait(true);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(int skip = 0, int take = 10)
        {
            return await _context.Posts
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(true);
        }
    }
}
