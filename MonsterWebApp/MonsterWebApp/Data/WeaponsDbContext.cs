using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWebApp.Data
{
    public class WeaponsDbContext : DbContext
    {
        public WeaponsDbContext(DbContextOptions<WeaponsDbContext> options) : base(options)
        {

        }

        DbSet<Weapons> Weapons { get; set; }

    }
}
