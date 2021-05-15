using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Application.Interfaces;
using TechBlog.Domain.Interfaces;
using TechBlog.Domain.Models;

namespace TechBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _PostRepository;

        public PostService(IRepository<Post> PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _PostRepository.FindAllAsync();
        }

        public async Task<Post> GetPostById(Guid id)
        {
            return await _PostRepository.FindById(id);
        }

        public async Task InsertNewPost(Post entity)
        {
            await _PostRepository.InsertOneAsync(entity);
        }

        public async Task UpdatePost(Post entity)
        {
            await _PostRepository.ReplaceOneAsync(entity);
        }

        public async Task DeletePostById(Guid id)
        {
            await _PostRepository.DeleteByIdAsync(id);
        }
    }
}
