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

        public DbSet<Weapons> Weapons { get; set; }

        public DbSet<UserModel> User { get; set; }

        public DbSet<UserWeapons> UserWeapons { get; set; }

        public static implicit operator WeaponsDbContext(HttpClient v)
        {
            throw new NotImplementedException();
        }
    }
}
