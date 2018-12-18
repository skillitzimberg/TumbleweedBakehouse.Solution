using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;


namespace TumbleweedBakehouse.Models
{

  public class Product
  {
    private string _name;
    private string _type;
    private string _description;
    private bool _availability;
    private float _price;
    private byte[] _img;
    private int _id;

    public Product (string name,
    string type,
    string description,
    byte[] img,
    bool availability,
    float price,
    int id = 0)
    {
      _name = name;
      _type = type;
      _description = description;
      _availability = availability;
      _img = img;
      _price = price;
      _id = id;
    }

    public bool GetProductAvailability()
    {
      return _availability;
    }

    public void SetProductAvailability(bool availability)
    {
      _availability = availability;
    }


    public string GetProductName()
    {
      return _name;
    }

    public void SetProductName(string name)
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

    public byte[] GetImg()
    {
      return _img;
    }

    public void SetImg(byte[] img)
    {
      _img =  img;
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
          int id = rdr.GetInt32(0);
          string name = rdr.GetString(1);
          string description = rdr.GetString(2);
          bool availability = rdr.GetBoolean(3);
          float price = rdr.GetFloat(4);
          string type= rdr.GetString(5);
          byte[] img = rdr.GetBytes(6);
          Product newProduct = new Product(name, type, description, img, availability, price, id);
          allProducts.Add(newProduct);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allProducts;
      }

      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO products (Name, description, img, availability, price, producttype) VALUES (@name, @description, @img,  @availability, @price,
          @type);";

          cmd.Parameters.AddWithValue("@name", this._name);

          cmd.Parameters.AddWithValue("@description", this._description);

          cmd.Parameters.AddWithValue("@availability", this._availability);

          cmd.Parameters.AddWithValue("@price", this._price);

          cmd.Parameters.AddWithValue("@type", this._type);

          cmd.Parameters.AddWithValue("@img", this._img);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }


        public static Product Find(int id)
        {

          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM products WHERE id = (@searchId);";

          cmd.Parameters.AddWithValue("@searchId", id);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int Id = 0;
          string productName = "";
          string type = "";
          string description = "";
          bool availability = true;
          float price = 0;
          byte[] img = {};

          while(rdr.Read())
          {
            Id = rdr.GetInt32(0);
            productName = rdr.GetString(1);
            type = rdr.GetString(5);
            description = rdr.GetString(2);
            availability = rdr.GetBoolean(3);
            price = rdr.GetFloat(4);
            img = rdr.GetBytes(6);
          }
          Product newProduct = new Product(productName, type, description, img, availability, price, id);
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return newProduct;
        }



        public void Edit(string name, string producttype, string description, byte[] img, bool availability, float price)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE products SET Name = @Name, description = @description, producttype = @producttype, img = @img, availability = @available, price = @price WHERE id = @searchId;";

          cmd.Parameters.AddWithValue("@searchId", _id);
          cmd.Parameters.AddWithValue("@Name",name);
          cmd.Parameters.AddWithValue("@description",description);
          cmd.Parameters.AddWithValue("@producttype", producttype);
          cmd.Parameters.AddWithValue("@img",img);
          cmd.Parameters.AddWithValue("@available", availability);
          cmd.Parameters.AddWithValue("@price", price);

          cmd.ExecuteNonQuery();
          _description = description;
          _name = name;
          _type = producttype;
          _img = img;
          _availability = availability;
          _price = price;

          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }



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
            bool nameEquality = this.GetProductName() == newProduct.GetProductName();
            bool typeEquality = this.GetProductType() == newProduct.GetProductType();
            bool descriptionEquality = this.GetDescription() == newProduct.GetDescription();
            bool priceEquality = this.GetPrice() == newProduct.GetPrice();
            bool imgEquality = this.GetImg() == newProduct.GetImg();

            return (idEquality && nameEquality && typeEquality && descriptionEquality && priceEquality && imgEquality);
          }
        }


      }
    }
