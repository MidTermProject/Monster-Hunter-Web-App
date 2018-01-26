using System;
using Xunit;
using MonsterWebApp.Models;
using Microsoft.EntityFrameworkCore;
using MonsterWebApp.Data;
using MonsterWebApp.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace XUnitMidTermProject1
{
    public class UnitTest1
    {
        WeaponsDbContext _context;

        DbContextOptions<WeaponsDbContext> options = new DbContextOptionsBuilder<WeaponsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;


        // Testing Get
        [Fact]
        public void ReturnsView()
        {
            // Arrange
            HomeController homeController = new HomeController(_context);

            // Act
            var result = homeController.Index(0);

            // Assert
            Assert.NotNull(result);
        }

        // Testing Result/connection to API side
        [Fact]
        public void GetBlade_ReturnAny()
        {
            using (var client = new HttpClient()) 
            {
                // Arrange
                HomeController controller = new HomeController(_context);
               
                // Act
                var result = controller.GetBlade();

                // Assert
                Assert.NotNull(result);
            }
        }

        
        [Fact]
        public void GetBlade_CheckID_ReturnID()
        {
            using (var client = new HttpClient())
            {
                // Arrange
                HomeController controller = new HomeController(_context);

                // Act
                var result = controller.GetBladeByID(2) as IActionResult;
                var result2 = result as ViewResult;

                // Assert
                Assert.IsType<string>(result2);
            }
        }

        //[Fact]
        //public void GetBlade_CheckID_ReturnID2()
        //{
        //    using (var client = new HttpClient())
        //    {
                
        //        Parent parent = new Parent { Id = 2 };
        //        var mock = new Mock<WeaponsDbContext>();

        //        mock.Setup(foo => foo.something()).Returns(parent);
        //        var sut = new HomeController(mock.Object);
        //        var cust2 = sut.GetBladebyID(2);
        //        Assert.Equal(cust.Id, cust2.Id);
                
               
        //    }
        //}




        /*
        [Fact]
        public async Task GetBlade_ReturnsObject()
        {
            using (var client = new HttpClient())
            {
                // Arrange
                var mock = new Mock<WeaponsDbContext>();
                var controller = new HomeController(mock.Object);

                mock.Setup(x => x.Weapons).Returns(controller);

                // Act
                var result = await controller.GetBlade();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<>>(
                    viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }
        */




    }
}

