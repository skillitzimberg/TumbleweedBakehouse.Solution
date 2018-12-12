
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using ValleyBread.Models;

namespace ValleyBread.Tests
{
  [TestClass]
  public class CustomerTests
   // : IDisposable
  {
    // public void Dispose()
    // {
    //   Customer.ClearAll();
    // }
    // public CustomerTest()
    // {
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Customer_Tests;";
    // }
    [TestMethod]
    public void CustomerConstructor_CreatesIntanceOfCustomer_Customer()
    {
      Customer newCustomer = new Customer("first", "last", 1, "email"," address", "city", "state", 3, 0);
      Assert.AreEqual(typeof(Customer), newCustomer.GetType());
    }
    [TestMethod]
    public void GetFirstName()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", 1, "email"," address", "city", "state", 3, 0);
       string result = newCustomer.GetFirstName();
       Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void SetFirstName_SetsName_String()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", 1, "email"," address", "city", "state", 3, 0);
      string updatedName = "jake";
      newCustomer.SetFirstName(updatedName);
      string result = newCustomer.GetFirstName();
      Assert.AreEqual(updatedName, result);
    }
  }
}
