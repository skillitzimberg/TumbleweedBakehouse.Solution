using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace TumbleWeedBakeHouse.Models
{

  public class Customer
  {
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _email;
    private string _homeAddress;
    private string _city;
    private string _state;
    private int _zipCode;
    private int _id;

    public Customer (string firstName, string lastName, string phoneNumber, string email, string address, string city, string state, int zip, int id = 0)
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
    public string GetFirstName() {
      return _firstName;
    }
    public void SetFirstName(string newName){
      _firstName = newName;
    }
    public string GetLastName(){
      return _lastName ;
    }
    public void SetLastName(string newName){
      _lastName = newName;
    }
    public string GetPhoneNumber(){
      return _phoneNumber;
    }
    public void SetPhoneNumber(string number){
      _phoneNumber = number;
    }
    public string GetEmail(){
      return _email;
    }
    public void SetEmail(string newEmail){
      _email = newEmail;
    }
    public string GetAddress()
    {
      return _homeAddress;
    }
    public void SetAddress(string newAddress)
    {
      _homeAddress = newAddress;
    }
}
}
