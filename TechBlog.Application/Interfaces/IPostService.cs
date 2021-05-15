using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Domain.Models;

namespace TechBlog.Application.Interfaces
{
    public interface IPostService
    {
        Task DeletePostById(Guid id);
        Task<Post> GetPostById(Guid id);
        Task<IEnumerable<Post>> GetPosts();
        Task InsertNewPost(Post entity);
        Task UpdatePost(Post entity);
    }
}
