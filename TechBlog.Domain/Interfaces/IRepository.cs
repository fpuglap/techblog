using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Domain.Interfaces
{
    public interface IRepository<T> where T : IDocument
    {
        Task<IQueryable<T>> AsQueryable();
        Task InsertOneAsync(T entity);
        Task ReplaceOneAsync(T entity);
        Task<T> FindById(Guid id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> predicate);
        Task InsertManyAsync(IEnumerable<T> entities);
        Task DeleteOneAsync(Expression<Func<T, bool>> predicate);
        Task DeleteByIdAsync(Guid id);
        Task DeleteManyAsync(Expression<Func<T, bool>> predicate);
    }
}
