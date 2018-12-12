
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
      Customer newCustomer = new Customer("first", "last", "1", "email"," address", "city", "state", 3, 0);
      Assert.AreEqual(typeof(Customer), newCustomer.GetType());
    }
    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", "1", "email"," address", "city", "state", 3, 0);
      string result = newCustomer.GetFirstName();
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void SetFirstName_SetsName_String()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", "1", "email"," address", "city", "state", 3, 0);
      string updatedName = "jake";
      newCustomer.SetFirstName(updatedName);
      string result = newCustomer.GetFirstName();
      Assert.AreEqual(updatedName, result);
    }
    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string name = "rudnicky";
      Customer newCustomer = new Customer("chris", name, "1", "email"," address", "city", "state", 3, 0);
      string result = newCustomer.GetLastName();
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void SetLastName_SetsName_String()
    {
      string name = "Rudnicky";
      Customer newCustomer = new Customer("chris", name, "1", "email"," address", "city", "state", 3, 0);
      string updatedName = "Morales";
      newCustomer.SetLastName(updatedName);
      string result = newCustomer.GetLastName();
      Assert.AreEqual(updatedName, result);
    }
    [TestMethod]
    public void GetPhoneNumber_ReturnsPhoneNumber_String()
    {
      string num = "7575640970";
      Customer newCustomer = new Customer("chris", "last", num, "email"," address", "city", "state", 3, 0);
      string result = newCustomer.GetPhoneNumber();
      Assert.AreEqual(num, result);
    }
    [TestMethod]
    public void SetPhoneNumber_SetsPhoneNumber_String()
    {
      string num = "7575640970";
      Customer newCustomer = new Customer("chris", "last", num, "email"," address", "city", "state", 3, 0);
      string newNumber = "7039945979";
      newCustomer.SetPhoneNumber(newNumber);
      string result = newCustomer.GetPhoneNumber();
      Assert.AreEqual(newNumber, result);
    }
    [TestMethod]
    public void GetEmail_ReturnsEmail_String()
    {
      string email= "chrisrudnicky@gmail.com";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", email, "address", "city", "state", 23188);
      string result = newCustomer.GetEmail();
      Assert.AreEqual(email, result);
    }
    [TestMethod]
    public void SetEmail_SetsEmail_String()
    {
      string email= "chrisrudnicky@gmail.com";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", email, "address", "city", "state", 23188);
      string newEmail ="gatheringguides@gmail.com";
      newCustomer.SetEmail(newEmail);
      string result = newCustomer.GetEmail();
      Assert.AreEqual(newEmail, result);
    }
    [TestMethod]
    public void GetAddress_ReturnsAddress_String()
    {
      string address= "103 Quaker Meeting House Rd";
      Customer newCustomer = new Customer ("chris", "Rudnicky", "7575640970", "email", address, "city", "state", 1, 2);
      string result = newCustomer.GetAddress();
      Assert.AreEqual(address, result);
     }
     [TestMethod]
     public void SetAddress_UpdatesAddress_String()
     {
       string address= "103 Quaker Meeting House Rd";
       Customer newCustomer = new Customer ("chris", "Rudnicky", "7575640970", "email", address, "city", "state", 1, 2);
       string newAddress ="37 NW Trinity Pl";
       newCustomer.SetAddress(newAddress);
       string result = newCustomer.GetAddress();
       Assert.AreEqual(newAddress, result);
     }
    [TestMethod]
    public void GetCity_ReturnsCity_String()
    {
      string city = "Boston";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", city, "state", 23188);
      string result = newCustomer.GetCity();
      Assert.AreEqual(city, result);
    }
    [TestMethod]
    public void SetCity_UpdatesCity_String()
    {
      string city= "Boston";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", city, "state", 23188);
      string newCity ="Portland";
      newCustomer.SetCity(newCity);
      string result = newCustomer.GetCity();
      Assert.AreEqual(newCity, result);
    }
    [TestMethod]
    public void GetState_ReturnsState_String()
    {
      string state ="VA";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", state , 23188);
      string result = newCustomer.GetState();
      Assert.AreEqual(state, result);
    }
    [TestMethod]
    public void SetState_UpdatesState_String()
    {
      string state ="VA";
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", state , 23188);
      string newState = "OR";
      newCustomer.SetState(newState);
      string result = newCustomer.GetState();
      Assert.AreEqual(newState, result);
    }
    [TestMethod]
    public void GetZip_ReturnsZipCode_Int()
    {
      int zip = 23188;
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , zip);
      int result = newCustomer.GetZip();
      Assert.AreEqual(zip, result);
    }
    [TestMethod]
    public void SetZip_UpdatesZipCode_Int()
    {
      int zip = 23188;
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , zip);
      int newZip = 97209;
      newCustomer.SetZip(newZip);
      int result = newCustomer.GetZip();
      Assert.AreEqual(newZip, result);
    }
  }
}
