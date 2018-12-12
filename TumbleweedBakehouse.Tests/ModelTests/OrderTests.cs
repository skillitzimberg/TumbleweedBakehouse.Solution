
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Tests 
{
  [TestClass]
  public class OrderTests : IDisposable
    {
        public void Dispose()
        {
            Order.ClearAll();
        }

        public OrderTests()
        {
            DBConfiguration.ConnectionString = "server = localhost; user id = root; password = root; port = 8889; database = tumbleweedbakehouse_test;";
        }

        [TestMethod]
        public void OrderObject_ObjectInstantiatesProperly_TypeofOrderTrue()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;

            //Act
            Order testOrder = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);

            //Assert
            Assert.AreEqual(typeof(Order), testOrder.GetType());

        }

        [TestMethod]
        public void Equals_ReturnsTrueIfIdsAreMatching_True()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;

            //Act
            Order testOrder1 = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);
            Order testOrder2 = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);

            //Assert
            Assert.AreEqual(testOrder1, testOrder2);

        }

        [TestMethod]
        public void Save_StoresOrderInDatabase_OrderList()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;
            Order testOrder = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);

            //Act
            testOrder.Save();
            List<Order> testList = new List<Order> { testOrder };
            List<Order> result = Order.GetAll();

            //Assert
            CollectionAssert.AreEqual(testList, result);


        }

        [TestMethod]
        public void ClearAll_ClearsOrderTableOfAllEntries_EmptyList()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;

            //Act
            Order testOrder = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);
            testOrder.Save();
            Order.ClearAll();
            List<Order> testList = Order.GetAll();
            List<Order> result = new List<Order> { };

            
            //Assert
            Assert.AreEqual(testList, result);

        }


  }
}
