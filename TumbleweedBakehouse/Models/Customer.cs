using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace TumbleweedBakehouse.Models
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
    public string GetAddress()  {
      return _homeAddress;
    }
    public void SetAddress(string newAddress)    {
      _homeAddress = newAddress;
    }
    public string GetCity(){
      return _city;
    }
    public void SetCity(string newCity){
      _city = newCity;
    }
    public string GetState(){
      return _state;
    }
    public void SetState(string newState){
      _state = newState;
    }
    public int GetZip(){
      return _zipCode;
    }
    public void SetZip(int newZip){
      _zipCode = newZip;
    }
    public int GetId(){
      return _id;
    }
    public string FirstLast(){
      string firstLast = _firstName + " " + _lastName;
      return firstLast;
    }

    public static List<Customer> GetAll(){
      List<Customer> allCustomers = new List<Customer> {};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM customers;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
     while(rdr.Read())
     {
       int customerId = rdr.GetInt32(0);
       string customerFirstName = rdr.GetString(1);
       string customerLastName = rdr.GetString(2);
       string customerPhoneNumber = rdr.GetString(3);
       string customerEmail = rdr.GetString(4);
       string customerAddress = rdr.GetString(5);
       string customerCity = rdr.GetString(6);
       string customerState = rdr.GetString(7);
       int customerZip = rdr.GetInt32(8);
       Customer newCustomer = new Customer(customerFirstName, customerLastName, customerPhoneNumber, customerEmail, customerAddress, customerCity, customerState, customerZip, customerId);
       allCustomers.Add(newCustomer);
     }
     conn.Close();
     if(conn != null)
     {
       conn.Dispose();
     }
     return allCustomers;
    }

    public override bool Equals(System.Object otherCustomer){
      if(!(otherCustomer is Customer))
      {
        return false;
      }
      else
      {
        Customer newCustomer = (Customer) otherCustomer;
        bool idEquality = (this.GetId() == newCustomer.GetId());
        bool firstNameEquality = (this.GetFirstName() == newCustomer.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == newCustomer.GetLastName());
        bool phoneNumEquality = (this.GetPhoneNumber() == newCustomer.GetPhoneNumber());
        bool emailEquality = (this.GetEmail() == newCustomer.GetEmail());
        bool addressEquality = (this.GetAddress() == newCustomer.GetAddress());
        bool cityEquality = (this.GetCity() == newCustomer.GetCity());
        bool stateEquality = (this.GetState() == newCustomer.GetState());
        bool zipEquality = (this.GetZip()== newCustomer.GetZip());
        return (idEquality && firstNameEquality && lastNameEquality && phoneNumEquality && emailEquality && addressEquality && cityEquality && stateEquality && zipEquality);
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText =@"INSERT INTO customers (firstName, lastName, phoneNumber, email, address, city, state, zipcode) VALUES (@CustomerFirstName, @CustomerLastName, @CustomerPhoneNumber, @CustomerEmail, @CustomerAddress, @CustomerCity, @CustomerState, @CustomerZipCode);";
      cmd.Parameters.AddWithValue("@CustomerFirstName",this._firstName);
      cmd.Parameters.AddWithValue("@CustomerLastName",this._lastName);
      cmd.Parameters.AddWithValue("@CustomerPhoneNumber",this._phoneNumber);
      cmd.Parameters.AddWithValue("@CustomerEmail",this._email);
      cmd.Parameters.AddWithValue("@CustomerAddress",this._homeAddress);
      cmd.Parameters.AddWithValue("@CustomerCity",this._city);
      cmd.Parameters.AddWithValue("@CustomerState",this._state);
      cmd.Parameters.AddWithValue("@CustomerZipCode",this._zipCode);
      cmd.ExecuteNonQuery();
      _id=(int)cmd.LastInsertedId;
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }



    public static void ClearAll(){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM customers;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
