using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TumbleweedBakehouse.Controllers;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace TumbleweedBakehouse.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          //Arrange
        ProductController controller = new ProductController();

        //Act
        ActionResult indexView = controller.Index();

        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    // [TestMethod]
    // public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    // {
    //   //Arrange
    //   ProductController controller = new ProductController();
    //
    //   //Act
    //   // FormFile newFormFile = new FormFile();
    //   IActionResult view = controller.Create("sourdough","raye","light and fluffy", true,3,1);
    //
    //   //Assert
    //   Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    // }


  }
}
