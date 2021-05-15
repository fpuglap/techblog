using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.ConsoleApp.Interfaces;

namespace TechBlog.ConsoleApp
{
    public class Application : IApplication
    {
        private readonly IData _data;

        public Application(IData data)
        {
            _data = data;
        }

        public void Run()
        {
            _data.FillDataBase();
        }
    }
}
