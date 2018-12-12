using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace ValleyBread.Models
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
      List<Product> productList = new List<Product>{};

      return productList;
    }

    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO clients (client, stylistId) VALUES (@client, @stylistId);";
    //   MySqlParameter customer = new MySqlParameter();
    //   customer.ParameterName = "@client";
    //   customer.Value = this._customer;
    //   cmd.Parameters.Add(customer);
    //   MySqlParameter stylistId = new MySqlParameter();
    //   stylistId.ParameterName = "@stylistId";
    //   stylistId.Value = this._stylistId;
    //   cmd.Parameters.Add(stylistId);
    //   cmd.ExecuteNonQuery();
    //   _id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }


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

    // public static void ClearAll()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM clients;";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }




    // public override bool Equals(System.Object otherProduct)
    // {
    //   if (!(otherProduct is Product))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Product newProduct = (Product) otherClient;
    //     bool idEquality = this.GetId() == newProduct.GetId();
    //     bool customerEquality = this.GetProductName() == newProduct.GetProductName();
    //     bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
    //     return (idEquality && customerEquality && stylistEquality);
    //   }


  }
}
