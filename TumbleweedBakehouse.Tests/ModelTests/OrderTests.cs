
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
        public void Save_StoresPartialOverloadOrderInDatabase_OrderObject()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testOrderReceivedDate = DateTime.Now;
            int testCustomer_Id = 1;
            Order testOrder = new Order(testOrderNumber, testOrderReceivedDate, testCustomer_Id);

            //Act
            testOrder.Save();
            List<Order> resultList = Order.GetAll();
            Order result = resultList[0];


            //Assert
            Assert.AreEqual(result, testOrder);
        }

        [TestMethod]
        public void Save_StoresFullOverloadOrderInDatabase_OrderObject()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testOrderReceivedDate = DateTime.Now;
            DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
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
        public void GetAll_ReturnsEmptyListFromDatabase_OrderList()
        {
            //Arrange
            List<Order> newList = new List<Order> { };

            //Act
            List<Order> resultList = Order.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, resultList);
        }

        [TestMethod]
        public void GetAll_GetsListWithObjects_OrderOList()
        {
            //Arrange
            int testOrderNumber1 = 1;
            DateTime testOrderReceivedDate1 = DateTime.Now;
            int testCustomer_Id1 = 1;
            Order testOrder1 = new Order(testOrderNumber1, testOrderReceivedDate1, testCustomer_Id1);

            int testOrderNumber2 = 2;
            DateTime testOrderReceivedDate2 = DateTime.Now;
            int testCustomer_Id2 = 2;
            Order testOrder2 = new Order(testOrderNumber2, testOrderReceivedDate2, testCustomer_Id2);

            int testOrderNumber3 = 3;
            DateTime testOrderReceivedDate3 = DateTime.Now;
            int testCustomer_Id3 = 3;
            Order testOrder3 = new Order(testOrderNumber3, testOrderReceivedDate3, testCustomer_Id3);

            //Act
            List<Order> testList = new List<Order> { testOrder1, testOrder2, testOrder3 };

            testOrder1.Save();
            testOrder2.Save();
            testOrder3.Save();

            List<Order> resultList = Order.GetAll();


            //Assert
            CollectionAssert.AreEqual(resultList, testList);
        }

        [TestMethod]
        public void Find_ReturnsCorrectOrderFromDatabase_Item()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testOrderReceivedDate = DateTime.Now;
            DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
            DateTime testDeliveredDate = DateTime.Parse("12/16/2018");
            string testPickupLocation = "Farmers Market 1";
            int testCustomer_Id = 1;
            Order testOrder = new Order(testOrderNumber, testOrderReceivedDate, testRequestedPickupDate, testDeliveredDate, testPickupLocation, testCustomer_Id);
            testOrder.Save();

            int testOrderNumber2 = 1;
            DateTime testOrderReceivedDate2 = DateTime.Now;
            DateTime testRequestedPickupDate2 = DateTime.Parse("12/15/2018");
            DateTime testDeliveredDate2 = DateTime.Parse("12/16/2018");
            string testPickupLocation2 = "Farmers Market 2";
            int testCustomer_Id2 = 1;
            Order testOrder2 = new Order(testOrderNumber2, testOrderReceivedDate2, testRequestedPickupDate2, testDeliveredDate2, testPickupLocation2, testCustomer_Id2);
            testOrder2.Save();

            //Act
            Order result = Order.Find(testOrder2.Id);

            //Assert
            Assert.AreEqual(testOrder2, result);
        }

        [TestMethod]
        public void Edit_UpdatesAnExistingOrder_Order()
        {
            //Arrange
            int testOrderNumber = 1;
            DateTime testOrderReceivedDate = DateTime.Now;
            DateTime testRequestedPickupDate = DateTime.Parse("12/15/2018");
            DateTime testDeliveredDate = DateTime.Parse("12/16/2018");
            string testPickupLocation = "Farmers Market 1";
            int testCustomer_Id = 1;
            Order testOrder = new Order(testOrderNumber, testOrderReceivedDate, testRequestedPickupDate, testDeliveredDate, testPickupLocation, testCustomer_Id);
            testOrder.Save();
            int resultID = testOrder.Id;

            //Act
            int testOrderNumber2 = 2;
            DateTime testOrderReceivedDate2 = testOrderReceivedDate.AddHours(2);
            DateTime testRequestedPickupDate2 = testRequestedPickupDate.AddDays(2);
            DateTime testDeliveredDate2 = testDeliveredDate.AddDays(2);
            string testPickupLocation2 = "Farmers Market 2";
            testOrder.Edit(testOrderNumber2, testOrderReceivedDate2, testRequestedPickupDate2, testDeliveredDate2, testPickupLocation2);

            Order result = new Order(testOrderNumber2, testOrderReceivedDate2, testRequestedPickupDate2, testDeliveredDate2, testPickupLocation2, testCustomer_Id, resultID);

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
