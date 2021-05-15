using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Infrastructure.DataAccess
{
    public class MongoDBDataAccess : IMongoDBDataAccess
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private readonly string _setting = "DatabaseSettings:MongoDBSettings:DatabaseStrings:Default";

        public MongoDBDataAccess(IConfiguration config)
        {
            _config = config;
            var client = new MongoClient(ConnectionString());
            _db = client.GetDatabase(_config.GetValue<string>(_setting));
        }

        public string ConnectionString()
        {
            return _config.GetValue<string>("DatabaseSettings:ConnectionStrings:Default");
        }

        public IMongoCollection<T> Collection<T>(string collection)
        {
            return _db.GetCollection<T>(collection);
        }
    }
}
