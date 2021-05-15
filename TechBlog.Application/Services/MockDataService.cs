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
    public class MockDataService : IDataService
    {
        private readonly IRepository<Post> _PostRepository;

        public MockDataService(IRepository<Post> PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public IEnumerable<Post> AllPosts =>
            new List<Post>
            {
                new Post{Title = "First Title", Content = "Test content to see something...", Public = true, IsPopular = true, Description = "First Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1542831371-29b0f74f9713?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8Y29kZXxlbnwwfDB8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"},
                new Post{Title = "Second Title", Content = "Test content to see something...", Public = true, IsPopular = true, Description = "Second Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1598662779094-110c2bad80b5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTB8fGtleWJvYXJkfGVufDB8MHwwfHw%3D&auto=format&fit=crop&w=500&q=60"},
                new Post{Title = "Third Title", Content = "Test content to see something...", Public = true, IsPopular = true, Description = "Third Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1619683322755-4545503f1afa?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTF8fGtleWJvYXJkc3xlbnwwfDB8Mnx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"},
                new Post{Title = "First Title", Content = "Test content to see something...", Public = true, Description = "First Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1594643469650-dd506331ff7a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1050&q=80"},
                new Post{Title = "Second Title", Content = "Test content to see something...", Public = true, Description = "Second Description", ImageThumbnailUrl = "https://media-exp1.licdn.com/dms/image/C561BAQHqRj67fBRsxw/company-background_10000/0/1589065247729?e=2159024400&v=beta&t=jRLW-B3xJiTSD1GJ-MXZs43_EqB40S51D6APzgZYEew"},
                new Post{Title = "Third Title", Content = "Test content to see something...", Public = true, Description = "Third Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1563986768711-b3bde3dc821e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1048&q=80"},
                new Post{Title = "First Title", Content = "Test content to see something...", Public = true, Description = "First Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80"},
                new Post{Title = "Second Title", Content = "Test content to see something...", Public = true, Description = "Second Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1613068687893-5e85b4638b56?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80"},
                new Post{Title = "Third Title", Content = "Test content to see something...", Public = true, Description = "Third Description", ImageThumbnailUrl = "https://images.unsplash.com/photo-1585547769764-bbd08e8b9b35?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1yZWxhdGVkfDV8fHxlbnwwfHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60"}
            };

        public void InsertMockData()
        {
            _PostRepository.InsertManyAsync(AllPosts);
        }
    }
}
