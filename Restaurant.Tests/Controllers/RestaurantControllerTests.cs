using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Controllers;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Tests.Controllers
{
    [TestClass]
   public class RestaurantControllerTests
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new FakeFoodDb();
            var controller = new ClassRestaurantsController(db);

            controller.Create(new ClassRestaurant());

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        public void Create_Does_Not_Save_Restaurant_When_Invalid()
        {
            var db = new FakeFoodDb();
            var controller = new ClassRestaurantsController(db);
            controller.ModelState.AddModelError("", "Invalid");

            controller.Create(new ClassRestaurant());

            Assert.AreEqual(0, db.Added.Count);
        }
    }
}
