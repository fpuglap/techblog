using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBlog.Domain.Models;

namespace TechBlog.MVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> PopularPosts { get; set; }
    }
}
