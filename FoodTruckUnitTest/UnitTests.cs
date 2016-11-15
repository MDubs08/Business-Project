using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Food_Truck.Controllers;
using Food_Truck.Models;
using System.Web.Mvc;

namespace FoodTruckUnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void HomeIndex()
        {

            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);

        }


        [TestMethod]
        public void HomeAbout()
        {

            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About", result.ViewName);

        }



        [TestMethod]
        public void HomeContact()
        {

            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Contact", result.ViewName);

        }



        [TestMethod]
        [Authorize(Roles = "Admin, Owner")]
        public void MenuCreate()
        {
            // Arrange
            MenuController controller = new MenuController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

    }
}





// Arrange

// Act

// Assert