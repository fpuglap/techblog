using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TechBlog.Domain.Models;

namespace TechBlog.MVC.Services
{
    public class Coffees
    {
        private readonly IHttpClientFactory _clientFactory;

        public string CoffeesId { get; set; }

        public List<Coffee> CoffeesBuyed = new();
        
        private Coffees(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public static Coffees GetCoffees(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<IHttpClientFactory>();

            string coffeesId = session.GetString("CoffeesId") ?? Guid.NewGuid().ToString();

            session.SetString("CoffeesId", coffeesId);

            //var test = new Coffees(context) { CoffeesId = coffeesId };

            return new Coffees(context) { CoffeesId = coffeesId };
        }

        public async Task AddCoffee(Post post)
        {
            var client = _clientFactory.CreateClient("local");

            var coffee = 
                (await client.GetFromJsonAsync<List<Coffee>>($"{ client.BaseAddress }coffees/")).SingleOrDefault(
                    c => c.Post.Id == post.Id && c.CoffeesId == CoffeesId);

            if (coffee == null)
            {
                coffee = new()
                {
                    Post = post,
                    CoffeesId = CoffeesId
                };

                await client.PostAsJsonAsync<Coffee>($"{ client.BaseAddress }coffees/", coffee);
            }
        }

        public async Task<List<Coffee>> GetCoffeesBuyed()
        {
            var client = _clientFactory.CreateClient("local");

            return (await client.GetFromJsonAsync<List<Coffee>>($"{ client.BaseAddress }coffees/")).Where(
                c => c.CoffeesId == CoffeesId)
                    .ToList();
        }
    }
}
