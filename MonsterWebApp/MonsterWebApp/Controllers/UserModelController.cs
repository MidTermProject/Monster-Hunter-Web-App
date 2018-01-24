using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonsterWebApp.Controllers
{
    public class UserModelController : Controller
    {
        private WeaponsDbContext _context;

        public UserModelController(WeaponsDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult UserSignUp()
        {
            return View();
        }
    }
}
