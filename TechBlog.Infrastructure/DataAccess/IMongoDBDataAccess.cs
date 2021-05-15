using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Infrastructure.DataAccess
{
    public interface IMongoDBDataAccess
    {
        IMongoCollection<T> Collection<T>(string table);
        string ConnectionString();
    }
}
