using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonsterWebApp.Data
{
    public class WeaponsDbContext : DbContext
    {
        public WeaponsDbContext(DbContextOptions<WeaponsDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Weapons> Weapons { get; set; }
        public DbSet<UserWeapon> UserWeapons { get; set; }

        public static implicit operator WeaponsDbContext(HttpClient v)
        {
            throw new NotImplementedException();
        }
    }
}
