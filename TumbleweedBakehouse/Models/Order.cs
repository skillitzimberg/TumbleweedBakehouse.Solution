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

        public Order(int orderNumber, DateTime orderReceivedDate, int customer_id, int id = 0)
        {
            this.Id = id;
            this.OrderNumber = orderNumber;
            this.ReceivedDate = orderReceivedDate;
            this.Customer_id = customer_id;
            this.PickupLocation = "";
        }

        public Order(int orderNumber, DateTime orderReceivedDate, DateTime requestedPickupDate, DateTime deliveredDate, string pickupLocation, int customer_id, int id = 0)
        {
            this.Id = id;
            this.OrderNumber = orderNumber;
            this.ReceivedDate = orderReceivedDate;
            this.RequestedPickupDate = requestedPickupDate;
            this.DeliveredDate = deliveredDate;
            this.PickupLocation = pickupLocation;
            this.Customer_id = customer_id;
            this.PickupLocation = pickupLocation;
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

                bool receivedDateEqualityYear = this.ReceivedDate.Year.Equals(newOrder.ReceivedDate.Year);
                bool receivedDateEqualityMonth = this.ReceivedDate.Month.Equals(newOrder.ReceivedDate.Month);
                bool receivedDateEqualityDay = this.ReceivedDate.Day.Equals(newOrder.ReceivedDate.Day);
                bool receivedDateEqualityHour = this.ReceivedDate.Hour.Equals(newOrder.ReceivedDate.Hour);
                bool receivedDateEqualityMinute = this.ReceivedDate.Minute.Equals(newOrder.ReceivedDate.Minute);

                bool requestedDateEqualityYear = this.RequestedPickupDate.Year.Equals(newOrder.RequestedPickupDate.Year);
                bool requestedDateEqualityMonth = this.RequestedPickupDate.Month.Equals(newOrder.RequestedPickupDate.Month);
                bool requestedDateEqualityDay = this.RequestedPickupDate.Day.Equals(newOrder.RequestedPickupDate.Day);
                bool requestedDateEqualityHour = this.RequestedPickupDate.Hour.Equals(newOrder.RequestedPickupDate.Hour);
                bool requestedDateEqualityMinute = this.RequestedPickupDate.Minute.Equals(newOrder.RequestedPickupDate.Minute);
                
                bool deliveredDateEqualityYear = this.DeliveredDate.Year.Equals(newOrder.DeliveredDate.Year);
                bool deliveredDateEqualityMonth = this.DeliveredDate.Month.Equals(newOrder.DeliveredDate.Month);
                bool deliveredDateEqualityDay = this.DeliveredDate.Day.Equals(newOrder.DeliveredDate.Day);
                bool deliveredDateEqualityHour = this.DeliveredDate.Hour.Equals(newOrder.DeliveredDate.Hour);
                bool deliveredDateEqualityMinute = this.DeliveredDate.Minute.Equals(newOrder.DeliveredDate.Minute);
                               
                bool pickupLocationEquality = this.PickupLocation == newOrder.PickupLocation;
                bool customer_idEquality = this.Customer_id.Equals(newOrder.Customer_id);

                return (idEquality && 
                    orderNumberEquality &&

                    receivedDateEqualityYear &&
                    receivedDateEqualityMonth &&
                    receivedDateEqualityDay &&
                    receivedDateEqualityHour &&
                    receivedDateEqualityMinute &&

                    requestedDateEqualityYear &&
                    requestedDateEqualityMonth &&
                    requestedDateEqualityDay &&
                    requestedDateEqualityHour &&
                    requestedDateEqualityMinute && 

                    deliveredDateEqualityYear &&
                    deliveredDateEqualityMonth &&
                    deliveredDateEqualityDay &&
                    deliveredDateEqualityHour &&
                    deliveredDateEqualityMinute && 

                    pickupLocationEquality && 
                    customer_idEquality);
            }
        }

        //CREATE: Creates a new Order
        public void Save() 
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO orders (orderNumber, receivedDate, requestedPickupDate, deliveredDate, pickupLocation, customer_id) 
                                            VALUES (@orderNumber, @receivedDate, @requestedPickupDate, @deliveredDate, @pickupLocation, @customer_id);";
            cmd.Parameters.AddWithValue("@orderNumber", this.OrderNumber);
            cmd.Parameters.AddWithValue("@receivedDate", this.ReceivedDate);
            cmd.Parameters.AddWithValue("@requestedPickupDate", this.RequestedPickupDate);
            cmd.Parameters.AddWithValue("@deliveredDate", this.DeliveredDate);
            cmd.Parameters.AddWithValue("@pickupLocation", this.PickupLocation);
            cmd.Parameters.AddWithValue("@customer_id", this.Customer_id);
            cmd.ExecuteNonQuery();
            this.Id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        //READ: Gets a list of all orders
        public static List<Order> GetAll() 
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
                int OrderNumber = rdr.GetInt32(1);
                DateTime ReceivedDate = rdr.GetDateTime(2);
                DateTime RequestedPickupDate = rdr.GetDateTime(3);
                DateTime DeliveredDate = rdr.GetDateTime(4);
                string PickupLocation = rdr.GetString(5);
                int Customer_id = rdr.GetInt32(6);
                Order newOrder = new Order(OrderNumber, ReceivedDate, RequestedPickupDate, DeliveredDate, PickupLocation, Customer_id, orderId);
                allOrders.Add(newOrder);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allOrders;
        }

        //READ: Finds a particular order given order Id
        public static Order Find(int searchId) 
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM orders WHERE id = (@searchId);";
            cmd.Parameters.AddWithValue("@searchId", searchId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int orderId = 0;
            int OrderNumber = 0;
            DateTime ReceivedDate = new DateTime();
            DateTime RequestedPickupDate = new DateTime();
            DateTime DeliveredDate = new DateTime();
            string PickupLocation = "";
            int Customer_id = 0;

            while (rdr.Read())
            {
                orderId = rdr.GetInt32(0);
                OrderNumber = rdr.GetInt32(1);
                ReceivedDate = rdr.GetDateTime(2);
                RequestedPickupDate = rdr.GetDateTime(3);
                DeliveredDate = rdr.GetDateTime(4);
                PickupLocation = rdr.GetString(5);
                Customer_id = rdr.GetInt32(6);

            }

            Order newOrder = new Order(OrderNumber, ReceivedDate, RequestedPickupDate, DeliveredDate, PickupLocation, Customer_id, orderId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return newOrder;
        }

        //UPDATE: This will edit an existing order
        public void Edit(int newOrderNumber, DateTime newReceivedDate, DateTime newRequestedPickupDate, DateTime newDeliveredDate, string newPickupLocation) 
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"UPDATE orders SET orderNumber = @newOrderNumber, receivedDate = @newReceivedDate, requestedPickupDate = @newRequestedPickupDate, deliveredDate = @newDeliveredDate, pickupLocation = @newPickupLocation WHERE id = @searchId;";

            cmd.Parameters.AddWithValue("@searchId", this.Id);
            cmd.Parameters.AddWithValue("@newOrderNumber", newOrderNumber);
            cmd.Parameters.AddWithValue("@newReceivedDate", newReceivedDate);
            cmd.Parameters.AddWithValue("@newRequestedPickupDate", newRequestedPickupDate);
            cmd.Parameters.AddWithValue("@newDeliveredDate", newDeliveredDate);
            cmd.Parameters.AddWithValue("@newPickupLocation", newPickupLocation);
            cmd.ExecuteNonQuery();

            this.OrderNumber = newOrderNumber;
            this.ReceivedDate = newReceivedDate;
            this.RequestedPickupDate = newRequestedPickupDate;
            this.DeliveredDate = newDeliveredDate;
            this.PickupLocation = newPickupLocation;
            this.Id = this.Id;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        //DELETE: Deletes ALL orders ((CAUTION!!!))
        public static void ClearAll() 
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