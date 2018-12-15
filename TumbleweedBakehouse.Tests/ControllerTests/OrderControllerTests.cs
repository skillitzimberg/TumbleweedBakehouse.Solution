using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TumbleweedBakehouse.Models;
using TumbleweedBakehouse.Controllers;
using System.Collections.Generic;

namespace TumbleweedBakehouse.Tests
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void Index_ReturnsAViewResult_True()
        {
            //Arrange
            OrderController controller = new OrderController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_AcceptsCorrectModel_Dictionary()
        {
            //Arrange
            ViewResult indexView = new OrderController().Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void Show_ReturnsAViewResult_True()
        {
            //Arrange
            OrderController controller = new OrderController();

            //Act
            ActionResult indexView = controller.Show();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsAViewResult_True()
        {
            //Arrange
            OrderController controller = new OrderController();

            //Act
            ActionResult newView = controller.New();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_AcceptsCorrectModel_Dictionary()
        {
            //Arrange
            ViewResult newView = new OrderController().New() as ViewResult;

            //Act
            var result = newView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }



    }
}
