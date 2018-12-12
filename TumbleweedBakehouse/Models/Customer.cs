using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace TumbleweedBakehouse.Models
{

  public class Customer
  {
    private string _firstName;
    private string _lastName;
    private int _phoneNumber;
    private string _email;
    private string _homeAddress;
    private string _city;
    private string _state;
    private int _zipCode;
    private int _id;

    public Customer (string firstName, string lastName, int phoneNumber, string email, string address, string city, string state, int zip, int id = 0)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
        _email = email;
        _homeAddress = address;
        _city = city;
        _state = state;
        _zipCode = zip;
        _id = id;
    }
}
}
