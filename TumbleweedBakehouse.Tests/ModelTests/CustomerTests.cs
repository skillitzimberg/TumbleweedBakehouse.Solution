
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleWeedBakeHouse.Models;

namespace TumbleWeedBakeHouse.Tests
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
    public void GetFirstName_ReturnsFirstName_String()
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
    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string name = "rudnicky";
      Customer newCustomer = new Customer("chris", name, 1, "email"," address", "city", "state", 3, 0);
      string result = newCustomer.GetLastName();
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void SetLastName_SetsName_String()
    {
      string name = "Rudnicky";
      Customer newCustomer = new Customer("chris", name, 1, "email"," address", "city", "state", 3, 0);
      string updatedName = "Morales";
      newCustomer.SetLastName(updatedName);
      string result = newCustomer.GetLastName();
      Assert.AreEqual(updatedName, result);
    }
  }
}
