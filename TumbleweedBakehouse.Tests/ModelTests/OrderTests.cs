
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleweedBakehouse.Models;
using System.Diagnostics;

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
            DateTime testOrderReceivedDate = DateTime.Now;
            DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
            //testRequestedPickupDate = testRequestedPickupDate.Replace
            DateTime testDeliveredDate = DateTime.Parse("12/16/2018");
            string testPickupLocation = "Farmers Market 1";
            int testCustomer_Id = 1;
            Order testOrder = new Order(testOrderNumber, testOrderReceivedDate, testRequestedPickupDate, testDeliveredDate, testPickupLocation, testCustomer_Id);

            //Act
            testOrder.Save();
            List<Order> resultList = Order.GetAll();
            Order result = resultList[0];


            //Assert
            Assert.AreEqual(result, testOrder);
        }

        [TestMethod]
        public void ClearAll_ClearsOrderTableOfAllEntries_EmptyList()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;

            Order testOrder = new Order(testOrderNumber, testReceivedDate, testCustomer_Id);
            testOrder.Save();

            //Act
            Order.ClearAll();
            List<Order> testList = Order.GetAll();

            
            //Assert
            Assert.AreEqual(testList.Count, 0);
        }
  }
}
