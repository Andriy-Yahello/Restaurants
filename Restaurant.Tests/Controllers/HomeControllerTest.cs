using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using Restaurant.Controllers;
using Restaurant.Tests.Features;
using Restaurant.Tests.Fakes;
using Restaurant.Models;

namespace Restaurant.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange

            var db = new FakeFoodDb();

            db.AddSet(TestData.Restaurants);
            //using fake in memmory db
            HomeController controller = new HomeController(db);
            controller.ControllerContext = new FakeControllerContext();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<RestaurantListVM> model = result.Model as IEnumerable<RestaurantListVM>;
            // Assert
            Assert.AreEqual(10, model.Count());
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert

            //to test ctr +R, A
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
