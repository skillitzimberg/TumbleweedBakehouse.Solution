using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace ValleyBread.Models
{

  public class Order
  {
        public int Id { get; set; }
        public int Order_number { get; set; }
        public Dictionary<string, object> OrderedProduct{ get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public DateTime Orderdelivereddate { get; set; }
        public int Customer_id { get; set; }

        public Order(int order_number, Dictionary<string, object> orderedProduct, DateTime orderReceivedDate, int customer_id, int id = 0)
        {
            this.Id = id;
            this.Order_number = order_number;
            this.OrderedProduct = orderedProduct;
            this.OrderReceivedDate = orderReceivedDate;
            this.Customer_id = customer_id;
        }
 
  }
}
