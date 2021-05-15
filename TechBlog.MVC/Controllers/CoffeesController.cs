using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TechBlog.Domain.Models;
using TechBlog.MVC.Services;

namespace TechBlog.MVC.Controllers
{
    public class CoffeesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly Coffees _coffees;

        public CoffeesController(IHttpClientFactory clientFactory, Coffees coffees)
        {
            _clientFactory = clientFactory;
            _coffees = coffees;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<ViewResult> Thanks()
        {
            var items = await _coffees.GetCoffeesBuyed();
            _coffees.CoffeesBuyed = items;

            return View();
        }

        public async Task<RedirectToActionResult> AddToCoffeesBuyed(Guid id)
        {
            var client = _clientFactory.CreateClient("local");

            var post = await client.GetFromJsonAsync<Post>($"{ client.BaseAddress }posts/{ id }");

            if (post != null)
            {
                await _coffees.AddCoffee(post);
            }

            return RedirectToAction("Thanks");
        }
    }
}
