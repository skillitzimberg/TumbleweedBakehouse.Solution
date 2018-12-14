using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
          ActionResult editView = controller.Edit(0);
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
        [TestMethod]
        public void Edit_HasCorrectModelType_Dictionary()
        {
          ViewResult editView = new CustomerController().Edit(1) as ViewResult;
          var result = editView.ViewData.Model;
          Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
    }
}
