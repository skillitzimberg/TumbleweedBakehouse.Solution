
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Tests
{
  [TestClass]
  public class ProductTest : IDisposable
  {

   public void Dispose()
    {
      Product.ClearAll();
    }

    public ProductTest()
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

    [TestMethod]
    public void Save_SavesToDatabase_ProductList()
    {
      //Arrange
      Product testProduct = new Product("sourdough","raye","light and fluffy",true,3,1);

      //Act
      testProduct.Save();
      List<Product> result = Product.GetAll();
      List<Product> testList = new List<Product>{testProduct};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsItems_ClientList()
    // {
    //   //Arrange
    //   string customer01 = "Clark Kent";
    //   string customer02 = "Hannibal Lecter";
    //   Client newClient1 = new Client(customer01, 1);
    //   newClient1.Save();
    //   Client newClient2 = new Client(customer02, 1);
    //   newClient2.Save();
    //   List<Client> newList = new List<Client> { newClient1, newClient2 };
    //
    //   //Act
    //   List<Client> result = Client.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfCustomersAreTheSame_Client()
    {
      // Arrange, Act
      Product firstProduct = new Product ("sourdough","raye","light and fluffy",true,3,1);
      Product secondProduct = new Product ("sourdough","raye","light and fluffy",true,3,1);

      // Assert
      Assert.AreEqual(firstProduct, secondProduct);
    }




  }
}
