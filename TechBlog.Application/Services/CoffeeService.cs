using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Application.Interfaces;
using TechBlog.Domain.Interfaces;
using TechBlog.Domain.Models;

namespace TechBlog.Application.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly IRepository<Coffee> _coffeeRepository;

        public CoffeeService(IRepository<Coffee> coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<IEnumerable<Coffee>> GetCoffees()
        {
            return await _coffeeRepository.FindAllAsync();
        }

        public async Task<Coffee> GetCoffeeById(Guid id)
        {
            return await _coffeeRepository.FindById(id);
        }

        public async Task InsertNewCoffee(Coffee entity)
        {
            await _coffeeRepository.InsertOneAsync(entity);
        }

        public async Task UpdateCoffee(Coffee entity)
        {
            await _coffeeRepository.ReplaceOneAsync(entity);
        }

        public async Task DeleteCoffeeById(Guid id)
        {
            await _coffeeRepository.DeleteByIdAsync(id);
        }
    }
}
