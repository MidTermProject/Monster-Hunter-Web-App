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
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace XUnitMidTermProject1
{
    public class HomeControllerTests
    {
        WeaponsDbContext _context;

        DbContextOptions<WeaponsDbContext> options = new DbContextOptionsBuilder<WeaponsDbContext>()

              .UseInMemoryDatabase(Guid.NewGuid().ToString())

              .Options;


        // Testing Get
        //[Fact]
        //public void ReturnsView()
        //{

        //    // Arrange
        //    HomeController homeController = new HomeController(_context);

            // Act
            var result = homeController.Index(0);

        //    // Assert
        //    Assert.NotNull(result);
        //}

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
        public void GetBlade()
        {
            using (var client = new HttpClient())
            {

                // Arrange
                HomeController controller = new HomeController(_context);

                // Act
                var result = controller.GetBlade();

                // Assert
                Assert.Contains("Name","Name");

            }
        }


        /*
        [Fact]
        public void GetBladeByID()
        {
                using (var client = new HttpClient())
            {

                // Arrange
                var controller = new HomeController(_context);
                controller.Request = new HttpRequestMessage();
                controller.Configuration = new HttpConfiguration();

                // Act
                var response = controller.GetBladeByID(10);

                // Assert
                WeaponsResult product;
                Assert.IsTrue(response.TryGetContentValue<>(out product));
                Assert.Equal(10, product.Id);

            }
        }
       

        
        [Fact]
        public void FilterBlade()
        {
             using (var client = new HttpClient())
            {

                // Arrange
                HomeController controller = new HomeController(_context);

                // Act
                var result = controller.FilterBlade("","",3);

                 // Assert

            }
        }
        */

    }
}

