using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Domain.Models;
using TechBlog.Infrastructure.DataAccess;

namespace TechBlog.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository(IConfiguration config, IMongoDBDataAccess dataAccess) : base(config, dataAccess)
        {
            collectionSetting = "DatabaseSettings:MongoDBSettings:CollectionStrings:Default";
            collectionStringName = _config.GetValue<string>(collectionSetting);
            _collection = _dataAccess.Collection<Post>(collectionStringName);
        }
    }
}
