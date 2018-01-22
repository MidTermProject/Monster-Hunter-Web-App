using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private //neednameDbContext _context;

        //public HomeController(//neednameDbContext context)
        //{
        //    _context = context;
        //}

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
