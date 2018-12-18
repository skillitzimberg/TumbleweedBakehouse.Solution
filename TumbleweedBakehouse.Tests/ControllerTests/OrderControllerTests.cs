using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TumbleweedBakehouse.Models;
using TumbleweedBakehouse.Controllers;
using System.Collections.Generic;
using System;

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
            ActionResult indexView = controller.Show(1);

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_AcceptsCorrectModel_Dictionary()
        {
            //Arrange
            Customer testCustomer = new Customer("Charley", "McGowan", "555-555-5555", "something@email.com", "123 Fun street", "Portland", "OR", 97222);
            testCustomer.Save();
            Order testOrder = new Order(DateTime.Parse("12/12/2012"), testCustomer.GetId());
            testOrder.Save();
            ViewResult showView = new OrderController().Show(testCustomer.GetId()) as ViewResult;

            //Act
            var result = showView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
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

        [TestMethod]
        public void Edit_ReturnsAViewResult_True()
        {
            //Arrange

            Customer testCustomer = new Customer("Charley", "McGowan", "555-555-5555", "something@email.com", "123 Fun street", "Portland", "OR", 97222);
            testCustomer.Save();
            Order testOrder = new Order(DateTime.Parse("12/12/2012"), testCustomer.GetId());
            testOrder.Save();
            OrderController controller = new OrderController();

            //Act
            ActionResult editView = controller.Edit(testCustomer.GetId());

            //Assert
            Assert.IsInstanceOfType(editView, typeof(ViewResult));
        }
    }
}
