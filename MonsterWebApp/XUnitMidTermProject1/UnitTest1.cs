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

namespace XUnitMidTermProject1
{
    public class UnitTest1
    {
        WeaponsDbContext _context;

        DbContextOptions<WeaponsDbContext> options = new DbContextOptionsBuilder<WeaponsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;


        // Testing Get for view controller
        [Fact]
        public void ReturnsView()
        {
            // Arrange
            HomeController homeController = new HomeController(_context);

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
        }

        // testing Result/connection to API side
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
        public async Task GetBlade_ReturnsObject()
        {
            using (var client = new HttpClient())
            {
                // Arrange
                var mockRepo = new Mock<WeaponsDbContext>();
                mockRepo.Setup(repo => repo.Weapons)
                    .Returns(Task.FromResult(HomeController()));
                var controller = new HomeController(mockRepo.Object);

                // Act
                var result = await controller.GetBlade();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                    viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }

        // Testing Models
        [Fact]
        public void TestName()
        {
            WeaponsResult n = new WeaponsResult();
            n.Name = "Monster";
            n.Name = "Hunter";

            Assert.Equal("Hunter", n.Name);
        }

      

        /*
        [Fact]
        public void PostWeaponTest()
        {


        }

        // Testing Models
        [Fact]
        public void WeaponID()
        {
            string testPoints = "90";
            test.Points = testPoints; // testing set

            Assert.Equal(testPoints, test.Points); // testing get
        }
        */


    }
}

