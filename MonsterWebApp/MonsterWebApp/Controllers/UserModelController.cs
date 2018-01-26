using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Data;
using MonsterWebApp.Models;

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

        [HttpGet]
        public IActionResult UserSignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserSignUp(UserModel userModel)
        {
            if (!await _context.Users.AnyAsync(u => u.UserName == userModel.UserName))
            {
                await _context.Users.AddAsync(userModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("UserFavoriteWeapons", userModel.UserName);
        }

        [HttpGet]
        public IActionResult UserFavoriteWeapons(string userName)
        {
            UserModel requestedUser = _context.Users.SingleOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (requestedUser == null) return RedirectToAction("Index", "Home");

            ViewData["LoggedInUserName"] = requestedUser.UserName;
            List<UserWeapon> userWeapons = _context.UserWeapons.Where(u => u.UserID == requestedUser.ID).ToList();

            return View(userWeapons);
        }
    }
}
