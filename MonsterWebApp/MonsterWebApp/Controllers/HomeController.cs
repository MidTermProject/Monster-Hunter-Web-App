using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Data;
using MonsterWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private WeaponsDbContext _context;

        public HomeController(WeaponsDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> GetBlade()
        {
            using (var client = new HttpClient())
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/blade");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);

                return View(deserialized);
            }
        }

        //[HttpPost]
        //static async Task<Uri> CreateProductAsync(WeaponsResult weaponresult)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/blades", product);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}


    }
}
