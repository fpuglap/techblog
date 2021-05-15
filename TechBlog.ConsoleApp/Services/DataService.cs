using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Application.Interfaces;
using TechBlog.ConsoleApp.Interfaces;

namespace TechBlog.ConsoleApp.Services
{
    public class DataService : IData
    {
        private readonly IDataService _data;

        public DataService(IDataService data)
        {
            _data = data;
        }

        public void FillDataBase()
        {
            _data.InsertMockData();
        }
    }
}
