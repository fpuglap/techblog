using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBlog.MVC.Services;
using TechBlog.MVC.ViewModels;

namespace TechBlog.MVC.Components
{
    public class CoffeesSummary : ViewComponent
    {
        private readonly Coffees _coffees;

        public CoffeesSummary(Coffees coffees)
        {
            _coffees = coffees;
        }

        public IViewComponentResult Invoke()
        {
            var items = _coffees.CoffeesBuyed;

            var coffeesViewModel = new CoffeesViewModel
            {
                Coffees = _coffees
            };

            return View(coffeesViewModel);
        }
    }
}
