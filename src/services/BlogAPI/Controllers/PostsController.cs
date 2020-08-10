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
        private readonly BlogContext context;

        public PostsController(BlogContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException($"{nameof(post)}");
            }

            _ = this.context.Posts.Add(post);
            _ = await this.context.SaveChangesAsync().ConfigureAwait(true);

            return this.CreatedAtAction(nameof(GetPost), new {
                id = post.PostId
            }, post);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            Post post = await this.context.Posts.FindAsync(id).ConfigureAwait(true);

            return post == null ? this.NotFound() : (ActionResult<Post>) post;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(int skip = 0, int take = 10)
        {
            return await this.context.Posts
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(true);
        }
    }
}
