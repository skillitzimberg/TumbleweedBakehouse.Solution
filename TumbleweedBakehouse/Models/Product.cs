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
    private string _imageString;

    public Product (
    string name,
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
    public string GetImageString(){
      return _imageString;
    }
    public void SetImageString(string imageString)
    {
      _imageString = imageString;
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
      // byte [] buffer = null;
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM products;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;


        while(rdr.Read())
        {
          var length = rdr.GetBytes(6, 0L, null, 0, 0);
          Console.WriteLine(length);
          Byte[] buffer = new Byte[length];
          rdr.GetBytes(6, 0L, buffer, 0, 0);
          Console.WriteLine(buffer);
          Console.WriteLine(buffer.GetType());


          // Console.WriteLine(rdr.GetByte(6));
          // rdr.GetBytes(6, 0L, buffer, 0, length);
          int id = rdr.GetInt32(0);
          string name = rdr.GetString(1);
          string description = rdr.GetString(2);
          bool availability = rdr.GetBoolean(3);
          float price = rdr.GetFloat(4);
          string type= rdr.GetString(5);
          // string picture = System.Text.Encoding.ETF8.GetString(buffer);
          // Console.WriteLine(img.GetType());
          Product newProduct = new Product(name, type, description, new byte[0], availability, price, id);
          var base64File = Convert.ToBase64String(buffer);
          string photo = String.Format("data:image/gif;base64,{0}", base64File);
          newProduct.SetImageString(photo);
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
          byte[] myByte = new byte[0];

          while(rdr.Read())
          {
            Id = rdr.GetInt32(0);
            productName = rdr.GetString(1);
            type = rdr.GetString(5);
            description = rdr.GetString(2);
            availability = rdr.GetBoolean(3);
            price = rdr.GetFloat(4);
            // img = rdr.GetByte(6);
          }
          Product newProduct = new Product(productName, type, description, new byte[0], availability, price, id);
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return newProduct;
        }



        public void Edit(string name, string producttype, string description, String img, bool availability, float price)
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
          _img = new byte[0];
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
