using System.Collections.Generic;
using TechBlog.Domain.Models;

namespace TechBlog.Application.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Post> AllPosts { get; }
        void InsertMockData();
    }
}