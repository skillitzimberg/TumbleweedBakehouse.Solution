// 
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MySql.Data.MySqlClient;
// using System.Collections.Generic;
// using System;
// using TumbleweedBakehouse.Models;
//
// namespace TumbleweedBakehouse.Tests
// {
//   [TestClass]
//   public class OrderTests
//   {
//         [TestMethod]
//         public void OrderClass_ObjectInstantiatesProperly_TypeofOrderTrue()
//         {
//             //Arrange
//             int testOrderNumber = 1;
//             Dictionary<string, object> testOrderedProduct = new Dictionary<string, object> { };
//             DateTime testOrderReceivedDate = DateTime.Now;
//             int testCustomer_Id = 1;
//
//             //Act
//             Order testOrder = new Order(testOrderNumber, testOrderedProduct, testOrderReceivedDate, testCustomer_Id);
//
//             //Assert
//             Assert.AreEqual(typeof(Order), testOrder.GetType());
//
//         }
//   }
// }
