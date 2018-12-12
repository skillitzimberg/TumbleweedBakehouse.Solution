
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using ValleyBread.Models;

namespace ValleyBread.Tests
{

  [TestClass]
  public class ProductTest
  {

    [TestMethod]
    public void ProductConstructor_CreatesInstanceofProduct_Product()
    {
      Product newProduct = new Product ("sourdough","light and fluffy",ture,3,1);

      Assert.AreEqual(typof(Product),newProduct.GetType());
    }






  }
}
