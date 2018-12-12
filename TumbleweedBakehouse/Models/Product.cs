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



  }
}
