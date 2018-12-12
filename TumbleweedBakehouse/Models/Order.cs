using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace TumbleweedBakehouse.Models
{

  public class Order
  {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public Dictionary<string, object> OrderedProduct{ get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime RequestedPickupDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string PickupLocation { get; set; }
        public int Customer_id { get; set; }

        public Order(int orderNumber, Dictionary<string, object> orderedProduct, DateTime orderReceivedDate, int customer_id, int id = 0)
        {
            this.Id = id;
            this.OrderNumber = orderNumber;
            this.OrderedProduct = orderedProduct;
            this.ReceivedDate = orderReceivedDate;
            this.Customer_id = customer_id;
        }

        public override bool Equals(System.Object otherOrder)
        {
            if (!(otherOrder is Order))
            {
                return false;
            }
            else
            {
                Order newOrder = (Order)otherOrder;
                bool idEquality = this.Id.Equals(newOrder.Id);
                bool orderNumberEquality = this.OrderNumber.Equals(newOrder.OrderNumber);
                bool receivedDateEquality = this.ReceivedDate.Equals(newOrder.ReceivedDate);
                bool requestedDateEquality = this.RequestedPickupDate.Equals(newOrder.RequestedPickupDate);
                bool deliveredDateEquality = this.DeliveredDate.Equals(newOrder.DeliveredDate);
                bool pickupLocationEquality = this.PickupLocation.Equals(newOrder.PickupLocation);
                bool customer_idEquality = this.Customer_id.Equals(newOrder.Customer_id);
                return (idEquality && orderNumberEquality && receivedDateEquality && requestedDateEquality && deliveredDateEquality && pickupLocationEquality && customer_idEquality);
            }
        }


        public void Save() // Create
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO orders (orderNumber) values (@orderNumber);";
            cmd.Parameters.AddWithValue("@orderNumber", this.OrderNumber);
            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Order> GetAll() //READ
        {
            List<Order> allOrders = new List<Order> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM orders;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int orderId = rdr.GetInt32(0);
                string orderName = rdr.GetString(1);
                Order newOrder = new Order(orderName, orderId);
                allOrders.Add(newOrder);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allOrders;
        }

        public static Order Find(int searchId) // READ
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM orders WHERE id = (@searchId);";
            cmd.Parameters.AddWithValue("@searchId", searchId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int OrderId = 0;
            string OrderName = "";
            while (rdr.Read())
            {
                OrderId = rdr.GetInt32(0);
                OrderName = rdr.GetString(1);
            }
            Order newOrder = new Order(OrderName, OrderId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newOrder;
        }

        public List<Customer> GetCustomers() // READ
        {
            List<Customer> allOrderCustomers = new List<Customer> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM customers WHERE order_id = @order_id;";
            cmd.Parameters.AddWithValue("@order_id", this.id);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int customerId = rdr.GetInt32(0);
                string customerDescription = rdr.GetString(1);
                int customerOrderId = rdr.GetInt32(2);
                Customer newCustomer = new Customer(customerDescription, customerOrderId, customerId);
                allOrderCustomers.Add(newCustomer);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allOrderCustomers;
        }

        public static void ClearAll() // DELETE
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM orders";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
