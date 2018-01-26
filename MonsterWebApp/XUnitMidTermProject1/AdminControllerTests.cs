using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MonsterWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using MonsterWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MonsterWebApp.Data;

//namespace XUnitMidTermProject1
//{
//    public class AdminControllerTests
//    {
//        DbContextOptions<WeaponsDbContext> options = new DbContextOptionsBuilder<WeaponsDbContext>()

//              .UseInMemoryDatabase(Guid.NewGuid().ToString())

//              .Options;

        //[Fact]
        //public void ReturnAdminView()
        //{
        //    // Arrange
        //    AdminController controller = new AdminController();

        //    // Act
        //    var result = controller.Index() as IActionResult;

        //    // Assert
        //    Assert.NotNull(result);

        //}

//        [Fact]
//        public async void ReturnAdminViewPost()
//        {
//            using (WeaponsDbContext _context = new WeaponsDbContext(options))
//            {
//                // Arrange
//                AdminController controller = new AdminController();
//                WeaponsResult weapons = new WeaponsResult()

//                {
//                    Name = "Jeffs Weapon",
//                    Description = "It's pretty cool",
//                    RawDamage = 10,
//                    ElementDamage = 10,
//                    ElementType = "Fire"
//                };

//                // Act
//               var result = await controller.Index(weapons);
//               OkObjectResult myResult = (OkObjectResult)result;

//               // Assert
//               Assert.Equal(200, myResult.StatusCode);
//            }
//        }
//    }
//}
