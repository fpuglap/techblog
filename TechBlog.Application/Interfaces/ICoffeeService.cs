using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Domain.Models;

namespace TechBlog.Application.Interfaces
{
    public interface ICoffeeService
    {
        Task DeleteCoffeeById(Guid id);
        Task<Coffee> GetCoffeeById(Guid id);
        Task<IEnumerable<Coffee>> GetCoffees();
        Task InsertNewCoffee(Coffee entity);
        Task UpdateCoffee(Coffee entity);
    }
}
