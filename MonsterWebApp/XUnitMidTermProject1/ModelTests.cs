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
    public class ModelTests
    {
        // Testing Parent
        [Fact]
        public void Parent_TestingGetter_ReturnObject()
        {
            // Arrange
            WeaponsResult parentblade = new WeaponsResult();

            // Act
            WeaponsResult testblade = new WeaponsResult();
            testblade.Parent = parentblade;

            // Assert
            Assert.IsType<WeaponsResult>(testblade.Parent);
        }


        [Fact]
        public void Parent_TestingSetter_ReturnObject()
        {
            // Arrange
            WeaponsResult p = new WeaponsResult() { Name = "value" };

            // Act
            p.Name = "notValue";

            // Assert
            Assert.Equal("notValue", p.Name);
        }
        


        // Testing HasChild
        [Fact]
        public void HasChild_TestingGetter_ReturnBool()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();
            WeaponsResult parent = new WeaponsResult();
            

            // Act
            n.HasChild = true;
            parent.HasChild = true;

            // Assert
            Assert.True(n.HasChild);
            Assert.True(parent.HasChild);
        }

        
        [Fact]
        public void HasChild_TestingSetter_ReturnBool()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { HasChild = false };

            // Act
            n.HasChild = true;

            // Assert
            Assert.True(n.HasChild);
        }
        

        // Testing WeaponClass
        [Fact]
        public void WeaponClass_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.WeaponClass = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.WeaponClass);
        }

        [Fact]
        public void WeaponClass_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Name = "Monster" };

            // Act
            n.WeaponClass = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.WeaponClass);
        }


        // Testing Name
        [Fact]
        public void Name_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Name = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Name);
        }

        [Fact]
        public void Name_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Name = "Monster" };

            // Act
            n.Name = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Name);
        }

        // Testing Description
        [Fact]
        public void Description_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Description = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Description);
        }

        [Fact]
        public void Descriptioin_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Description = "Monster" };

            // Act
            n.Description = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Description);
        }

        // Testing RawDamage
        [Fact]
        public void RawDamage_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.RawDamage = 5;

            // Assert
            Assert.Equal(5, n.RawDamage);
        }

        [Fact]
        public void RawDamage_TestingSetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { RawDamage = 9 };

            // Act
            n.RawDamage = 10;

            // Assert
            Assert.Equal(10, n.RawDamage);
        }

        
        // Testing ElementType
        [Fact]
        public void ElementType_TestingGetter_ReturnString()
        {
           // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.ElementType = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.ElementType);
        }
        
        
        [Fact]
        public void ElementType_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Description = "Monster" };

            // Act
            n.ElementType = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.ElementType);
        }
        


        // Testing ElementDamage
        [Fact]
        public void ElementDamage_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.ElementDamage = 3;

            // Assert
            Assert.Equal(3, n.ElementDamage);
        }

        [Fact]
        public void ElementDamage_TestingSetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { ElementDamage = 4 };

            // Act
            n.ElementDamage = 5;

            // Assert
            Assert.Equal(5, n.ElementDamage);
        }

        // Testing Sharpness
        [Fact]
        public void Sharpness_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Sharpness = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Sharpness);
        }

        [Fact]
        public void Sharpness_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Sharpness = "Monster" };

            // Act
            n.Sharpness = "Hunter";

            // Assert
            Assert.Equal("Hunter", n.Sharpness);
        }

        // Testing Rarity
        [Fact]
        public void Rarity_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Rarity = 9;

            // Assert
            Assert.Equal(9, n.Rarity);
        }

        [Fact]
        public void Rarity_TestingSetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Rarity = 9 };

            // Act
            n.Rarity = 5;

            // Assert
            Assert.Equal(5, n.Rarity);
        }

        // Testing Affinity
        [Fact]
        public void Affinity_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Affinity = 2;

            // Assert
            Assert.Equal(2, n.Affinity);
        }

        [Fact]
        public void Affinity_TestingSetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Affinity = 9 };

            // Act
            n.Affinity = 4;

            // Assert
            Assert.Equal(4, n.Affinity);
        }

        // Testing Slots
        [Fact]
        public void Slots_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Slots = 5;

            // Assert
            Assert.Equal(5, n.Slots);
        }

        [Fact]
        public void Slots_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Slots = 3 };

            // Act
            n.Slots = 2;

            // Assert
            Assert.Equal(2, n.Slots);
        }

        // Testing Defense
        [Fact]
        public void Defense_TestingGetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Defense = 8;

            // Assert
            Assert.Equal(8, n.Defense);
        }

        [Fact]
        public void Defense_TestingSetter_ReturnLong()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Defense = 1 };

            // Act
            n.Defense = 5;

            // Assert
            Assert.Equal(5, n.Defense);
        }

        // Testing ImgUrl
        [Fact]
        public void ImgUrl_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.ImgUrl = "url";

            // Assert
            Assert.Equal("url", n.ImgUrl);
        }

        [Fact]
        public void ImgUrl_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { ImgUrl = "url" };

            // Act
            n.ImgUrl = "notUrl";

            // Assert
            Assert.Equal("notUrl", n.ImgUrl);
        }

        // Testing Materials
        [Fact]
        public void Materials_TestingGetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult();

            // Act
            n.Materials = "url";

            // Assert
            Assert.Equal("url", n.Materials);
        }

        [Fact]
        public void Materials_TestingSetter_ReturnString()
        {
            // Arrange
            WeaponsResult n = new WeaponsResult() { Materials = "url" };

            // Act
            n.Materials = "notUrl";

            // Assert
            Assert.Equal("notUrl", n.Materials);
        }

        /// <summary>
        /// User Models
        /// </summary>

        // Testing UserName
        [Fact]
        public void UserName_TestingGetter_ReturnString()
        {
            // Arrange
            UserModel n = new UserModel();

            // Act
            n.UserName = "name";

            // Assert
            Assert.Equal("name", n.UserName);
        }

        [Fact]
        public void UserName_TestingSetter_ReturnString()
        {
            // Arrange
            UserModel n = new UserModel() { UserName = "name" };

            // Act
            n.UserName = "diffName";

            // Assert
            Assert.Equal("diffName", n.UserName);
        }


        /// <summary>
        /// User Weapons
        /// </summary>

        // Testing WeaponID
        [Fact]
        public void WeaponID_TestingGetter_ReturnInt()
        {
            // Arrange
            UserWeapon n = new UserWeapon();

            // Act
            n.WeaponID = 4;

            // Assert
            Assert.Equal(4, n.WeaponID);
        }

        [Fact]
        public void WeaponID_TestingSetter_ReturnInt()
        {
            // Arrange
            UserWeapon n = new UserWeapon() { WeaponID = 6 };

            // Act
            n.WeaponID = 3;

            // Assert
            Assert.Equal(3, n.WeaponID);
        }

        // Testing UserID
        [Fact]
        public void UserID_TestingGetter_ReturnInt()
        {
            // Arrange
            UserWeapon n = new UserWeapon();

            // Act
            n.UserID = 4;

            // Assert
            Assert.Equal(4, n.UserID);
        }

        [Fact]
        public void UserID_TestingSetter_ReturnInt()
        {
            // Arrange
            UserWeapon n = new UserWeapon() { UserID = 6 };

            // Act
            n.UserID = 3;

            // Assert
            Assert.Equal(3, n.UserID);
        }

        // Testing WeaponName
        [Fact]
        public void WeaponName_TestingGetter_ReturnString()
        {
            // Arrange
            UserWeapon n = new UserWeapon();

            // Act
            n.WeaponName = "name";

            // Assert
            Assert.Equal("name", n.WeaponName);
        }

        [Fact]
        public void WeaponName_TestingSetter_ReturnString()
        {
            // Arrange
            UserWeapon n = new UserWeapon() { WeaponName = "name" };

            // Act
            n.WeaponName = "diffName";

            // Assert
            Assert.Equal("diffName", n.WeaponName);
        }

        // Testing UserName
        [Fact]
        public void UserName2_TestingGetter_ReturnString()
        {
            // Arrange
            UserWeapon n = new UserWeapon();

            // Act
            n.UserName = "name";

            // Assert
            Assert.Equal("name", n.UserName);
        }

        [Fact]
        public void UserName2_TestingSetter_ReturnString()
        {
            // Arrange
            UserWeapon n = new UserWeapon() { UserName = "name" };

            // Act
            n.UserName = "diffName";

            // Assert
            Assert.Equal("diffName", n.UserName);
        }

        /// <summary>
        /// Weapons
        /// </summary>

        // Testing WeaponID
        [Fact]
        public void WeaponID2_TestingGetter_ReturnInt()
        {
            // Arrange
            Weapons n = new Weapons();

            // Act
            n.WeaponID = 4;

            // Assert
            Assert.Equal(4, n.WeaponID);
        }

        [Fact]
        public void WeaponID2_TestingSetter_ReturnInt()
        {
            // Arrange
            Weapons n = new Weapons() { WeaponID = 6 };

            // Act
            n.WeaponID = 3;

            // Assert
            Assert.Equal(3, n.WeaponID);
        }

        // Testing WeaponName
        [Fact]
        public void WeaponName2_TestingGetter_ReturnString()
        {
            // Arrange
            Weapons n = new Weapons();

            // Act
            n.WeaponName = "name";

            // Assert
            Assert.Equal("name", n.WeaponName);
        }

        [Fact]
        public void WeaponName2_TestingSetter_ReturnString()
        {
            // Arrange
            Weapons n = new Weapons() { WeaponName = "name" };

            // Act
            n.WeaponName = "diffName";

            // Assert
            Assert.Equal("diffName", n.WeaponName);
        }
    }
}
