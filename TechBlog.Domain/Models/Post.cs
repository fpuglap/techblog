using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Domain.Interfaces;

namespace TechBlog.Domain.Models
{
    public class Post : Document
    {
        public string Title { get; set; }
        public int Views { get; set; } = new Random().Next(500, 1000);
        public string Description { get; set; }
        public string Content { get; set; }
        public bool Public { get; set; }
        public bool IsPopular { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
