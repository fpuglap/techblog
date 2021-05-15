using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBlog.Application.Interfaces;
using TechBlog.Domain.Models;

namespace TechBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : Controller
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeesController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        // GET: api/<CoffeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetAsync()
        {
            var coffees = await _coffeeService.GetCoffees();

            if (coffees == null)
            {
                return NotFound();
            }

            return Ok(coffees);
        }

        // GET api/<CoffeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coffee>> GetAsync(Guid id)
        {
            var coffee = await _coffeeService.GetCoffeeById(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return Ok(coffee);
        }

        // Coffee api/<CoffeesController>
        [HttpPost]
        public async Task CoffeeAsync([FromBody] Coffee value)
        {
            await _coffeeService.InsertNewCoffee(value);
        }

        // PUT api/<CoffeesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromBody] Coffee value)
        {
            await _coffeeService.UpdateCoffee(value);
        }

        // DELETE api/<CoffeesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _coffeeService.DeleteCoffeeById(id);
        }
    }
}
