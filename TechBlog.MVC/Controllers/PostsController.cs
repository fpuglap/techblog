using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TechBlog.Domain.Models;
using TechBlog.MVC.ViewModels;

namespace TechBlog.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PostsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: PostController
        public async Task<ViewResult> List()
        {
            var client = _clientFactory.CreateClient("local");

            PostsListViewModel postsListViewModel = new();

            postsListViewModel.Posts = await client.GetFromJsonAsync<List<Post>>($"{ client.BaseAddress }posts/");

            return View(postsListViewModel);
        }

        // GET: PostController
        public async Task<ViewResult> Details(Guid id)
        {
            var client = _clientFactory.CreateClient("local");

            var post = await client.GetFromJsonAsync<Post>($"{ client.BaseAddress }posts/{ id }");

            return View(post);
        }
    }
}
