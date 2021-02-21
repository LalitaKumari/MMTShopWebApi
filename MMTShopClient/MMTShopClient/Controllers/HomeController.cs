using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMTShopClient.Models;
using MMTShopClient.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTShopClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> featuredProduct = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53761/api/FeaturedProduct"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    featuredProduct = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(featuredProduct);
        }

        public async Task<IActionResult> Products(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53761/api/Product/" + categoryId))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
