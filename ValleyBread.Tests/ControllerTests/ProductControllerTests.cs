using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ValleyBread.Controllers;

namespace ValleyBread.Tests
{
    [TestClass]
    public class YourClassControllerTest
    {
      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
          //Arrange
        YourClassController controller = new YourClassController();

        //Act
        ActionResult indexView = controller.Index();

        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

  }
}
