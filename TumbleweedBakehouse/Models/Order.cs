using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TumbleweedBakehouse.Models
{
	public class Order
	{
		public int Id { get; set; } //Order database id
		public int OrderNumber { get; set; } //Order Number per customer
		public DateTime ReceivedDate { get; set; } //Date the order was created
		public DateTime RequestedPickupDate { get; set; } //Date requested for the order to be picked up
		public DateTime DeliveredDate { get; set; } //Date the order was actually delivered
		public string PickupLocation { get; set; } //The location the order will be picked up
		public int Customer_id { get; set; } //Customer database id

		public Order(DateTime requestedPickupDate, int customer_id, int id = 0)
		{
			this.Id = id;
			this.ReceivedDate = DateTime.Now;
			this.RequestedPickupDate = requestedPickupDate;
			this.Customer_id = customer_id;
			this.PickupLocation = "";
		}

		public Order(int orderNumber, DateTime requestedPickupDate, int customer_id, int id = 0)
		{
			this.Id = id;
			this.OrderNumber = orderNumber;
			this.ReceivedDate = DateTime.Now;
			this.RequestedPickupDate = requestedPickupDate;
			this.Customer_id = customer_id;
			this.PickupLocation = "";
		}

		public Order(int orderNumber, DateTime requestedPickupDate, string pickupLocation, int customer_id, int id = 0)
		{
			this.Id = id;
			this.OrderNumber = orderNumber;
			this.ReceivedDate = DateTime.Now;
			this.RequestedPickupDate = requestedPickupDate;
			this.Customer_id = customer_id;
			this.PickupLocation = pickupLocation;
		}

		public Order(int orderNumber, DateTime requestedPickupDate, DateTime deliveredDate, string pickupLocation, int customer_id, int id = 0)
		{
			this.Id = id;
			this.OrderNumber = orderNumber;
			this.ReceivedDate = DateTime.Now;
			this.RequestedPickupDate = requestedPickupDate;
			this.DeliveredDate = deliveredDate;
			this.PickupLocation = pickupLocation;
			this.Customer_id = customer_id;
			this.PickupLocation = pickupLocation;
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

			cmd.CommandText = @"SELECT COUNT(*) FROM orders WHERE customer_id = @customer_id;";

			cmd.Parameters.AddWithValue("@customer_id", this.Customer_id);

			var rdr = cmd.ExecuteReader() as MySqlDataReader;

			while (rdr.Read())
			{
				int newOrderNumberValue = rdr.GetInt32(0);
				this.OrderNumber = newOrderNumberValue + 1;
			}
			conn.Close();

			conn.Open();
			cmd.CommandText = @"INSERT INTO orders (orderNumber, receivedDate, requestedPickupDate, deliveredDate, pickupLocation, customer_id)
											VALUES (@orderNumber, @receivedDate, @requestedPickupDate, @deliveredDate, @pickupLocation, @customer_id);";
			cmd.Parameters.AddWithValue("@orderNumber", this.OrderNumber);
			cmd.Parameters.AddWithValue("@receivedDate", this.ReceivedDate);
			cmd.Parameters.AddWithValue("@requestedPickupDate", this.RequestedPickupDate);
			cmd.Parameters.AddWithValue("@deliveredDate", this.DeliveredDate);
			cmd.Parameters.AddWithValue("@pickupLocation", this.PickupLocation);

			cmd.ExecuteNonQuery();
			this.Id = (int)cmd.LastInsertedId;

			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
		}

		//CREATE: Adds a product to the order
		public void AddProductToOrder(Product newProduct, int qty)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO products_orders (product_id, order_id, productQty) VALUES (@ProductId, @OrderId, @ProductQty);";
			cmd.Parameters.AddWithValue("@ProductId", newProduct.GetId());
			cmd.Parameters.AddWithValue("@OrderId", this.Id);
			cmd.Parameters.AddWithValue("@ProductQty", qty);
			cmd.ExecuteNonQuery();
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

		//READ: this will get all products in the order
		public List<Product> GetProductsInOrder()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT products.*
									, products_orders.productQty
								FROM orders
								JOIN products_orders
								ON orders.id = products_orders.order_id
								JOIN products
								ON products_orders.product_id = products.id
								WHERE orders.id = @OrderId;";

			cmd.Parameters.AddWithValue("@OrderId", this.Id);

			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			List<Product> products = new List<Product> { };

			while (rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				string description = rdr.GetString(2);
				bool availability = rdr.GetBoolean(3);
				float price = rdr.GetFloat(4);
				string type = rdr.GetString(5);
				string url = rdr.GetString(6);
				Product foundProduct = new Product(name, type, description, url, availability, price, id);
				products.Add(foundProduct);
			}

			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
			return products;
		}

		//READ: this will get all products QUANTITY in the order
		public List<int> GetProductsQTYInOrder()

		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT products.id
									, products.Name
									, products_orders.productQty
								FROM orders
								JOIN products_orders
								ON orders.id = products_orders.order_id
								JOIN products
								ON products_orders.product_id = products.id
								WHERE orders.id = @OrderId;";

			cmd.Parameters.AddWithValue("@OrderId", this.Id);

			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			List<int> productQty = new List<int>{};

			while (rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				int qty = rdr.GetInt32(2);
				productQty.Add(qty);
			}

			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
			return productQty;
		}

		//READ: this will get individual product QUANTITY in an order
		public int GetProductsQTYInOrder(int productId)

		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT products.id
									, products.Name
									, products_orders.productQty
								FROM orders
								JOIN products_orders
								ON orders.id = products_orders.order_id
								JOIN products
								ON products_orders.product_id = products.id
								WHERE orders.id = @OrderId AND products.id = @ProductId;";

			cmd.Parameters.AddWithValue("@OrderId", this.Id);
			cmd.Parameters.AddWithValue("@ProductId", productId);

			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			int qty = 0;

			while (rdr.Read())
			{
				qty = rdr.GetInt32(2);
			}

			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
			return qty;
		}

		//UPDATE: This will edit an existing order
		public void Edit(int newOrderNumber, DateTime newReceivedDate, DateTime newRequestedPickupDate, DateTime newDeliveredDate, string newPickupLocation)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			var cmd = conn.CreateCommand() as MySqlCommand;

			cmd.CommandText = @"UPDATE orders SET receivedDate = @newReceivedDate, requestedPickupDate = @newRequestedPickupDate, deliveredDate = @newDeliveredDate, pickupLocation = @newPickupLocation WHERE id = @searchId;";

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

		//UPDATE: This will edit an existing order with less inputs
		public void Edit(DateTime newRequestedPickupDate, DateTime newDeliveredDate, string newPickupLocation)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			var cmd = conn.CreateCommand() as MySqlCommand;

			cmd.CommandText = @"UPDATE orders SET requestedPickupDate = @newRequestedPickupDate, deliveredDate = @newDeliveredDate, pickupLocation = @newPickupLocation WHERE id = @searchId;";

			cmd.Parameters.AddWithValue("@searchId", this.Id);
			cmd.Parameters.AddWithValue("@newRequestedPickupDate", newRequestedPickupDate);
			cmd.Parameters.AddWithValue("@newDeliveredDate", newDeliveredDate);
			cmd.Parameters.AddWithValue("@newPickupLocation", newPickupLocation);
			cmd.ExecuteNonQuery();

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

		//UPDATE: this will update individual product QUANTITY in an order
		public void UpdateProductQTYinOrder(int productId, int newQty)

		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

			cmd.CommandText = @"UPDATE products_orders 
									SET productQTY = @ProductQTY 
									WHERE order_id = @OrderId 
									AND product_id = @ProductId;";

			cmd.Parameters.AddWithValue("@OrderId", this.Id);
			cmd.Parameters.AddWithValue("@ProductId", productId);
			cmd.Parameters.AddWithValue("@ProductQTY", newQty);

			cmd.ExecuteNonQuery();

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
