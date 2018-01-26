using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                // Update url in the following line.
                client.BaseAddress = new Uri("http://monsterhunterapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/material");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                //deserialized.
                Material[] deserialized = Material.FromJson(stringResult);
                ViewBag.Materials = deserialized;
                WeaponsResult wr = new WeaponsResult
                {
                    Materials = new List<String>()
                };
                return View(wr);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(WeaponsResult weaponresult)
        {
            var serializedWeapon = Serialize.ToJson(weaponresult);
            var httpContent = new StringContent(serializedWeapon, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://monsterhunterapi.azurewebsites.net/api/blade", httpContent);
            }

            return Ok(201);
        }
    }
}
