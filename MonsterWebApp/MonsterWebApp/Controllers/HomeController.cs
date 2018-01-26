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

        /// <summary>
        /// Our get all to the APIs Blade table.
        /// </summary>
        /// <returns>List of all available blades in API Blade table</returns>
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

        /// <summary>
        /// Used to grab a weapon from the Blade table by id number.
        /// </summary>
        /// <param name="id">The unique identifier for each blade</param>
        /// <returns>One Blade Object</returns>
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
        



        public async Task<IActionResult> Filter(string weaponClass, string element, int rarity)
        {
            using (var client = new HttpClient())
            {
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                if (weaponClass.Contains(' '))
                {
                    //find and replace logic 
                    // weaponClass = newname witih %20 
                }

                var response = await client.GetAsync($"/api/blade/{weaponClass}?element={element}?rarity={rarity}");
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
                if(weaponClass.Contains(' '))
                {
                    //find and replace logic 
                    // weaponClass = newname witih %20 
                }

                var response = await client.GetAsync($"/api/blade/{weaponClass}?element={element}?rarity={rarity}");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);

                return View(deserialized);            
                
            }
        }

        //chain 3 methods, one for get by weapon class, one for get by element, one for get by rarity,
        //THEN we'll go ahead and have a master method that calls them all IF all fields are accurate?

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
