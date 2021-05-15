using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Domain.Interfaces;
using TechBlog.Infrastructure.DataAccess;

namespace TechBlog.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : IDocument
    {
        protected readonly IConfiguration _config;
        protected readonly IMongoDBDataAccess _dataAccess;
        protected IMongoCollection<T> _collection;
        protected string collectionSetting;
        protected string collectionStringName;

        public GenericRepository(IConfiguration config, IMongoDBDataAccess dataAccess)
        {
            _config = config;
            _dataAccess = dataAccess;
        }

        public virtual async Task<IQueryable<T>> AsQueryable()
        {
            return await Task.Run(() => _collection.AsQueryable());
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            var data = await collection.FindAsync<T>(new BsonDocument());
            return data.ToList();
        }

        public virtual async Task<T> FindById(Guid id)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await collection.Find(filter).FirstAsync();
        }

        public virtual async Task InsertOneAsync(T entity)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            await collection.InsertOneAsync(entity);
        }

        public virtual async Task ReplaceOneAsync(T entity)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            await collection.FindOneAndReplaceAsync(filter, entity);
        }

        public virtual async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            return await collection.Find(predicate).ToListAsync();
        }

        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public virtual async Task DeleteOneAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            await collection.FindOneAndDeleteAsync(predicate);
        }

        public virtual async Task DeleteByIdAsync(Guid id)
        {
            var collection = _dataAccess.Collection<T>(collectionStringName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            await collection.FindOneAndDeleteAsync(filter);
        }

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> predicate)
        {
            await _collection.DeleteManyAsync(predicate);
        }
    }
}
