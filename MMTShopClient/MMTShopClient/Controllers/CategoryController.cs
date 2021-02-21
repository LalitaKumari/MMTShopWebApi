using Microsoft.AspNetCore.Mvc;
using MMTShopClient.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTShopClient.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Category> Categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53761/api/Product"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(Categories);
        }
    }
}
