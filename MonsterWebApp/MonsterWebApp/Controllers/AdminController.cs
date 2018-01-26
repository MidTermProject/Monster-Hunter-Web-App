using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(WeaponsResult weaponresult)
        {
            if (!ModelState.IsValid) return BadRequest();
            var serializedWeapon = weaponresult.ToJson();
            var httpContent = new StringContent(serializedWeapon, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
                await client.PostAsync("http://monsterhunterapi.azurewebsites.net/api/blade", httpContent);
            
            return RedirectToAction("Index");
        }
    }
}
