using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWebApp.Data
{
    public class UserModelDbContext : DbContext
    {
        public UserModelDbContext(DbContextOptions<UserModelDbContext> options): base(options)
        {
           
        }

        DbSet<UserModel> User { get; set; }

    }
}
