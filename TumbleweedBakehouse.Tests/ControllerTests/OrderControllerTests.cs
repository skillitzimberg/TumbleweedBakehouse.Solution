using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TumbleweedBakehouse.Controllers;

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
        public void Show_ReturnsAViewResult_True()
        {
            //Arrange
            OrderController controller = new OrderController();

            //Act
            ActionResult indexView = controller.Show();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

    }
}
