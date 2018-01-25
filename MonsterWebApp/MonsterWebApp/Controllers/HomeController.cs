using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Data;
using MonsterWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private WeaponsDbContext _context;

        public HttpConfiguration Configuration { get; set; }

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
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/blade");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);

                return View(deserialized);
            }
        }

        public async Task<IActionResult> GetBladeByID(int id)
        {
            using (var client = new HttpClient())
            {
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/blade/{id}");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);

                return View(deserialized);
            }
        }

        public async Task<IActionResult> FilterBlade(string weaponClass, string element, int rarity)
        {
            using (var client = new HttpClient())
            {
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/blade/{weaponClass}?{element}?{rarity}");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);

                return View(deserialized);            
                
            }
        }

        //public async Task<IActionResult> FilterElement(string weaponClass, string element)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // Update url in the following line.
        //        client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
        //        var response = await client.GetAsync($"/api/blade/{weaponClass}?{element}");
        //        response.EnsureSuccessStatusCode();
        //        var stringResult = await response.Content.ReadAsStringAsync();
        //        //deserialized.
        //        var deserialized = WeaponsResult.FromJson(stringResult);

        //        return View(deserialized);

        //    }
        //}




        //[HttpPost]
        //public  async Task<Uri> CreateWeaponAsync(WeaponsResult weaponresult)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response = await client.PostAsJsonAsync(
        //      "api/blades", Weapons);
        //        response.EnsureSuccessStatusCode();

        //        // return URI of the created resource.
        //        return response.Headers.Location;

        //    }

        //}


    }
}
