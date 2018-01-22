using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWebApp.Data
{
    public class UserWeaponsDbContext : DbContext
    {
        public UserWeaponsDbContext(DbContextOptions<UserWeaponsDbContext> options) : base(options)
        {

        }

        DbSet<UserWeapons> UserWeapons { get; set; }

    }
}
