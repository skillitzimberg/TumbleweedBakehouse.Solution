
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using ValleyBread.Models;

namespace TumbleweedBakeHouse.Tests : IDisposable
{
  [TestClass]
  public class ProductTest
  {
    
   public void Dispose()
    {
      Client.ClearAll();
    }

    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tumbleweedbakehouse_test;";
    }


    [TestMethod]
    public void ProductConstructor_CreatesInstanceofProduct_Product()
    {
      Product newProduct = new Product ("sourdough","raye","light and fluffy",true,3,1);

      Assert.AreEqual(typeof(Product),newProduct.GetType());
    }

    [TestMethod]
    public void Getall_GetEmptyList_List()
    {

      List<Product> productList = new List<Product>{};
      List<Product> result = Product.GetAll();

      CollectionAssert.AreEqual(productList,result);
    }




  }
}
