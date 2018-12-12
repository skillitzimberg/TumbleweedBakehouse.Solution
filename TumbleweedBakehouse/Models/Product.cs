using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace TumbleweedBakehouse.Models
{

  public class Product
  {
    private string _name;
    private string _type;
    private string _description;
    private bool _availability;
    private float _price;
    private int _id;

    public Product (string name, string type, string description, bool availability, float price, int id = 0)
    {
      _name = name;
      _type = type;
      _description = description;
      _availability = availability;
      _price = price;
      _id = id;
    }

    public string GetProductName()
    {
      return _name;
    }

    public void SetProductNamedName(string name)
    {
      _name = name;
    }

    public string GetProductType()
    {
      return _type;
    }

    public void SetProductType(string type)
    {
      _type = type;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string description)
    {
      _description = description;
    }

    public float GetPrice()
    {
      return _price;
    }

    public void SetPrice(float price)
    {
      _price = price;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Product> GetAll()
    {
      List<Product> allProducts = new List<Product> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM products;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string productName = rdr.GetString(1);
        string description = rdr.GetString(2);
        bool availability = rdr.Getbool(3);
        int price = rdr.GetInt32(4);
        string productType= rdr.GetString(5);
        Product newClient = new Product(productName, productType, description, availability, price, id);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO products (name, description, availability, price, type) VALUES (@name, @description, @availability, @price,
      @type);";
      MySqlParameter breadname = new MySqlParameter();
      breadname.ParameterName = "@name";
      breadname.Value = this._name;
      cmd.Parameters.Add(name;

      MySqlParameter newdescription = new MySqlParameter();
      newdescription.ParameterName = "@description";
      newdescription.Value = this._description;
      cmd.Parameters.Add(description);

      MySqlParameter newAvailability = new MySqlParameter();
      newAvailability.ParameterName = "@availability";
      newAvailability.Value = this._availability;
      cmd.Parameters.Add(availability);

      MySqlParameter newPrice = new MySqlParameter();
      newPrice.ParameterName = "@price";
      newPrice.Value = this._price;
      cmd.Parameters.Add(price);

      MySqlParameter newType = new MySqlParameter();
      newType.ParameterName = "@type";
      newType.Value = this._type;
      cmd.Parameters.Add(type);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    // public static Product Find()
    // {
    //
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int clientId = 0;
    //   string clientName = "";
    //   int clientStylistId = 0;
    //   while(rdr.Read())
    //   {
    //     clientId = rdr.GetInt32(0);
    //     clientName = rdr.GetString(1);
    //     clientStylistId = rdr.GetInt32(2);
    //   }
    //   Client newClient = new Client(clientName, clientStylistId, clientId);
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newClient;
    // }


    // public void Edit(string newCustomer)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE Clients SET client = @newCustomer WHERE id = @searchId;";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = _id;
    //   cmd.Parameters.Add(searchId);
    //   MySqlParameter customer = new MySqlParameter();
    //   customer.ParameterName = "@newCustomer";
    //   customer.Value = newCustomer;
    //   cmd.Parameters.Add(customer);
    //   cmd.ExecuteNonQuery();
    //   _customer = newCustomer;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM products;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }




    public override bool Equals(System.Object otherProduct)
    {
      if (!(otherProduct is Product))
      {
        return false;
      }
      else
      {
        Product newProduct = (Product) otherProduct;
        bool idEquality = this.GetId() == newProduct.GetId();
        bool productEquality = this.GetProductName() == newProduct.GetProductName();
        // bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && productEquality );
      }


  }
}
