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
            UserModel userId = _context.Users.FirstOrDefault(x => x.UserName == userModel.UserName);
            return RedirectToAction("Index", "Home", new { id = userId.ID});
        }

        [HttpGet]
        public IActionResult UserFavoriteWeapons(string userName)
        {
            if (String.IsNullOrEmpty(userName)) return RedirectToAction("Index", "Home");
            UserModel requestedUser = _context.Users.SingleOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (requestedUser == null) return RedirectToAction("Index", "Home");

            List<UserWeapon> userWeapons = _context.UserWeapons.Where(u => u.UserID == requestedUser.ID).ToList();

            return View(userWeapons);
        }

        public IActionResult AddWeapoonToUser(string weaponName, string userName)
        {
            Weapons uw = _context.Weapons.FirstOrDefault(w => w.WeaponName == weaponName);

            Weapons weapon;

            if (uw == null)
            {
                Weapons w = new Weapons {WeaponName = weaponName};
                _context.Weapons.Add(w);
                _context.SaveChanges();
                weapon = _context.Weapons.Last();
            }
            else
                weapon = uw;

            
            if (_context.UserWeapons.Any(x => x.WeaponName != weaponName))
            {
                UserWeapon nuw = new UserWeapon
                {
                    WeaponID = weapon.ID,
                    WeaponName = weaponName,
                    UserName = "Test"
                };
                _context.UserWeapons.Add(nuw);
                _context.SaveChanges();
            }

            return RedirectToAction("UserFavoriteWeapons");
        }
    }
}
