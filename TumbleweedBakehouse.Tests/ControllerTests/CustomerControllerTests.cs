using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TumbleweedBakehouse.Controllers;

namespace TumbleweedBakehouse.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            CustomerController controller = new CustomerController();
            //Act
            ActionResult indexView = controller.Index();
            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult editView = controller.Edit();
          Assert.IsInstanceOfType(editView,typeof(ViewResult));
        }
        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult newView = controller.New();
          Assert.IsInstanceOfType(newView,typeof(ViewResult));
        }
        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult showView = controller.Show();
          Assert.IsInstanceOfType(showView,typeof(ViewResult));
        }
    }
}
