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
    public class CoffeeRepository : GenericRepository<Coffee>
    {
        public CoffeeRepository(IConfiguration config, IMongoDBDataAccess dataAccess) : base(config, dataAccess)
        {
            collectionSetting = "DatabaseSettings:MongoDBSettings:CollectionStrings:Coffees";
            collectionStringName = _config.GetValue<string>(collectionSetting);
            _collection = _dataAccess.Collection<Coffee>(collectionStringName);
        }
    }
}
