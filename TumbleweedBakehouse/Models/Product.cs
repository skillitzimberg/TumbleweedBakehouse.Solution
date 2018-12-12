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
      List<Product> productList = new List<Product>{};

      return productList;
    }

    public void Save()
    {

    }

    //public static Product Find()
    //{
    //  return 0;
    //}

    public void Edit(string newProduct)
    {

    }

    public static void ClearAll()
    {

    }




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
