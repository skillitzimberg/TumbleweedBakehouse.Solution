using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Tests
{
    [TestClass]
    public class CustomerTests : IDisposable
    {
        public void Dispose()
        {
            Customer.ClearAll();
            Order.ClearAll();
        }

        public CustomerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tumbleweedbakehouse_test;";
        }

        [TestMethod]
        public void CustomerConstructor_CreatesIntanceOfCustomer_Customer()
        {
            Customer newCustomer = new Customer("first", "last", "1", "email", " address", "city", "state", 3, 0);
            Assert.AreEqual(typeof(Customer), newCustomer.GetType());
        }

        [TestMethod]
        public void GetFirstName_ReturnsFirstName_String()
        {
            string name = "chris";
            Customer newCustomer = new Customer(name, "last", "1", "email", " address", "city", "state", 3, 0);
            string result = newCustomer.GetFirstName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void SetFirstName_SetsName_String()
        {
            string name = "chris";
            Customer newCustomer = new Customer(name, "last", "1", "email", " address", "city", "state", 3, 0);
            string updatedName = "jake";
            newCustomer.SetFirstName(updatedName);
            string result = newCustomer.GetFirstName();
            Assert.AreEqual(updatedName, result);
        }

        [TestMethod]
        public void GetLastName_ReturnsLastName_String()
        {
            string name = "rudnicky";
            Customer newCustomer = new Customer("chris", name, "1", "email", " address", "city", "state", 3, 0);
            string result = newCustomer.GetLastName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void SetLastName_SetsName_String()
        {
            string name = "Rudnicky";
            Customer newCustomer = new Customer("chris", name, "1", "email", " address", "city", "state", 3, 0);
            string updatedName = "Morales";
            newCustomer.SetLastName(updatedName);
            string result = newCustomer.GetLastName();
            Assert.AreEqual(updatedName, result);
        }

        [TestMethod]
        public void GetPhoneNumber_ReturnsPhoneNumber_String()
        {
            string num = "7575640970";
            Customer newCustomer = new Customer("chris", "last", num, "email", " address", "city", "state", 3, 0);
            string result = newCustomer.GetPhoneNumber();
            Assert.AreEqual(num, result);
        }

        [TestMethod]
        public void SetPhoneNumber_SetsPhoneNumber_String()
        {
            string num = "7575640970";
            Customer newCustomer = new Customer("chris", "last", num, "email", " address", "city", "state", 3, 0);
            string newNumber = "7039945979";
            newCustomer.SetPhoneNumber(newNumber);
            string result = newCustomer.GetPhoneNumber();
            Assert.AreEqual(newNumber, result);
        }

        [TestMethod]
        public void GetEmail_ReturnsEmail_String()
        {
            string email = "chrisrudnicky@gmail.com";
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", email, "address", "city", "state", 23188);
            string result = newCustomer.GetEmail();
            Assert.AreEqual(email, result);
        }

        [TestMethod]
        public void SetEmail_SetsEmail_String()
        {
            string email = "chrisrudnicky@gmail.com";
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", email, "address", "city", "state", 23188);
            string newEmail = "gatheringguides@gmail.com";
            newCustomer.SetEmail(newEmail);
            string result = newCustomer.GetEmail();
            Assert.AreEqual(newEmail, result);
        }

        [TestMethod]
        public void GetAddress_ReturnsAddress_String()
        {
            string address = "103 Quaker Meeting House Rd";
            Customer newCustomer = new Customer("chris", "Rudnicky", "7575640970", "email", address, "city", "state", 1, 2);
            string result = newCustomer.GetAddress();
            Assert.AreEqual(address, result);
        }

        [TestMethod]
        public void SetAddress_UpdatesAddress_String()
        {
            string address = "103 Quaker Meeting House Rd";
            Customer newCustomer = new Customer("chris", "Rudnicky", "7575640970", "email", address, "city", "state", 1, 2);
            string newAddress = "37 NW Trinity Pl";
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
            string city = "Boston";
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", city, "state", 23188);
            string newCity = "Portland";
            newCustomer.SetCity(newCity);
            string result = newCustomer.GetCity();
            Assert.AreEqual(newCity, result);
        }

        [TestMethod]
        public void GetState_ReturnsState_String()
        {
            string state = "VA";
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", state, 23188);
            string result = newCustomer.GetState();
            Assert.AreEqual(state, result);
        }

        [TestMethod]
        public void SetState_UpdatesState_String()
        {
            string state = "VA";
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", state, 23188);
            string newState = "OR";
            newCustomer.SetState(newState);
            string result = newCustomer.GetState();
            Assert.AreEqual(newState, result);
        }

        [TestMethod]
        public void GetZip_ReturnsZipCode_Int()
        {
            int zip = 23188;
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", zip);
            int result = newCustomer.GetZip();
            Assert.AreEqual(zip, result);
        }

        [TestMethod]
        public void SetZip_UpdatesZipCode_Int()
        {
            int zip = 23188;
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", zip);
            int newZip = 97209;
            newCustomer.SetZip(newZip);
            int result = newCustomer.GetZip();
            Assert.AreEqual(newZip, result);
        }

        [TestMethod]
        public void GetFirstLast_ConcatsFirstAndLastName_String()
        {
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            string firstLast = "chris rudnicky";
            string result = newCustomer.GetFirstLast();
            Assert.AreEqual(firstLast, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ItemList()
        {
            List<Customer> newCustomerList = new List<Customer> { };
            List<Customer> result = Customer.GetAll();
            CollectionAssert.AreEqual(newCustomerList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsPopulatedList_ItemList()
        {
            //Arrange
            Customer newCustomer1 = new Customer("Charley", "McGowan", "5551231234", "fun@gmail.com", "123 Funzone St.", "Portland", "OR", 97211);
            newCustomer1.Save();
            Customer newCustomer2 = new Customer("Charley2", "McGowan2", "5552231234", "fun2@gmail.com", "1232 Funzone St.", "Portland2", "WA", 97212);
            newCustomer2.Save();

            //Act
            List<Customer> result = Customer.GetAll();
            List<Customer> testList = new List<Customer> { newCustomer1, newCustomer2 };

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfPropertiesAreTheSame_Customer()
        {
            Customer newCustomer1 = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            Customer newCustomer2 = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            Assert.AreEqual(newCustomer1, newCustomer2);
        }
    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Customer()
    {
      Customer newCustomer1 = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      Customer newCustomer2 = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      Assert.AreEqual(newCustomer1, newCustomer2);
    }
    [TestMethod]
    public void Save_SavesToDataBase_CustomerList()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      List<Customer> result = Customer.GetAll();
      List<Customer> testList = new List<Customer>{newCustomer};
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      Customer savedCustomer = Customer.GetAll()[0];
      int result = savedCustomer.GetId();
      int testId = newCustomer.GetId();
      Assert.AreEqual(result, testId);
    }
    [TestMethod]
    public void Find_ReturnsCorrectCustomerFromDatabase_Customer()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      Customer foundCustomer = Customer.Find(newCustomer.GetId());
      Assert.AreEqual(newCustomer, foundCustomer);
    }
    [TestMethod]
    public void Edit_UpdatesCustomerInDataBase_StringandInt()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      string newString ="jake";
      newCustomer.Edit(newString, "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      string result = Customer.Find(newCustomer.GetId()).GetFirstName();
      Assert.AreEqual(newString, result);
    }
    [TestMethod]
    public void FindOrders_ReturnsEmptyOrderList_Order()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      List<Order> newList = new List<Order> {};
      List<Order> result = Customer.FindOrders(newCustomer.GetId());
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void FindOrder_RetrievesAllOrderswithcustomer_OrderList()
    {
      //Arrange
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      int testOrderNumber = 1;
      DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
      string testPickupLocation = "Farmers Market 1";
      int testCustomer_Id = 1;
      Order testOrder = new Order(testOrderNumber, testRequestedPickupDate, testPickupLocation, newCustomer.GetId());
      testOrder.Save();


        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            newCustomer.Save();
            Customer savedCustomer = Customer.GetAll()[0];
            int result = savedCustomer.GetId();
            int testId = newCustomer.GetId();
            Assert.AreEqual(result, testId);
        }

        [TestMethod]
        public void Find_ReturnsCorrectCustomerFromDatabase_Customer()
        {
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            newCustomer.Save();
            Customer foundCustomer = Customer.Find(newCustomer.GetId());
            Assert.AreEqual(newCustomer, foundCustomer);
        }

        [TestMethod]
        public void Edit_UpdatesCustomerInDataBase_StringandInt()
        {
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            newCustomer.Save();
            string newString = "jake";
            newCustomer.Edit(newString, "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            string result = Customer.Find(newCustomer.GetId()).GetFirstName();
            Assert.AreEqual(newString, result);
        }

        [TestMethod]
        public void FindOrders_ReturnsEmptyOrderList_Order()
        {
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            List<Order> newList = new List<Order> { };
            List<Order> result = Customer.FindOrders(newCustomer.GetId());
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void FindOrder_RetrievesAllOrderswithcustomer_OrderList()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
            string testPickupLocation = "Farmers Market 1";
            int testCustomer_Id = 1;
            Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state", 23188);
            newCustomer.Save();
            Order testOrder = new Order(testOrderNumber, testRequestedPickupDate, testPickupLocation, newCustomer.GetId());
            testOrder.Save();

            //Act
            List<Order> testList = Customer.FindOrders(newCustomer.GetId());
            List<Order> result = new List<Order> { testOrder };

            //Assert
            CollectionAssert.AreEqual(result, testList);
        }
    }
}
