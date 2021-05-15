using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Domain.Models
{
    public class Coffee : Document
    {
        public Post Post { get; set; }
        public string CoffeesId { get; set; }
    }
}
