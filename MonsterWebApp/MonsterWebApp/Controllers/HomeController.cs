using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Data;
using MonsterWebApp.Models;
using Newtonsoft.Json.Linq;

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
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                UserModel userModel = _context.Users.FirstOrDefault(u => u.ID == id);
                if (userModel != null) ViewData["LoggedInUserName"] = userModel.UserName;
            }
            return View();
        }

        public async Task<IActionResult> GetBlade()
        {
            using (var client = new HttpClient())
            {
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync("/api/blade");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                var deserialized = WeaponsResult.FromJson(stringResult);
                foreach (var x in deserialized)
                {
                    Weapons weapon = new Weapons
                    {
                        WeaponName = x.Name,
                        WeaponID = (int) x.Id
                    };
                    _context.Weapons.Add(weapon);
                }
                _context.SaveChanges();
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
    }
}
