using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBlog.Application.Interfaces;
using TechBlog.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAsync()
        {
            var posts = await _postService.GetPosts();

            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetAsync(Guid id)
        {
            var post = await _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task PostAsync([FromBody] Post value)
        {
            await _postService.InsertNewPost(value);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromBody] Post value)
        {
            await _postService.UpdatePost(value);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _postService.DeletePostById(id);
        }
    }
}
