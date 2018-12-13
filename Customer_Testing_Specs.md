# Customer Class Tests
<sup>_Chris Rudnicky_</sup>

---
This file contains testing information for the Customer Class Model. Click the links below to learn more about each test.

- [Constructor Instantiation]("#CustomerConstructor_CreatesInstanceOfCustomer_Customer)
- [Get Set Tests](#property-get-set-tests)
- [Creating a full name](#FirstLast_ConcatsFirstAndLastName_String)
- [GetAll Returning Empty List](#GetAll-Tests)
- [Equality Override Testing](#public-override-bool-equals)
- [Save](#save-test-methods)
---
## CustomerConstructor_CreatesIntanceOfCustomer_Customer

This test will test to see if our constructor works. Expect this test to automatically pass because without a constructor, C# will not be able to run any code.

#### CustomerTests.cs
    [TestMethod]
    public void CustomerConstructor_CreatesIntanceOfCustomer_Customer()
    {
      Customer newCustomer = new Customer("first", "last", 1, "email"," address", "city", "state", 3, 0);
    }

#### Customer.cs
Class properties:

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

Constructor:

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


---

## Get Set Tests

Due to the similarities between the get/set test methods used to access the properties of the Customer object I will only list on example of how to fail and pass both a Get method and a Set method.

### Get Method
Any method that starts with`Get()` will simple return a property of the class.

#### CustomerTests.cs
    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", 1, "email"," address", "city", "state", 3, 0);
       string result = newCustomer.GetFirstName();
       Assert.AreEqual(name, result);
    }

#### Customer.cs
<sup>The code block below is written to **pass**</sup>

    public string GetFirstName()
    {
      return _firstName;
    }

To **fail** this test just return an irrelevant value of the same datatype.

### Set Method
Any method that starts with Set will update a property of the class.

#### CustomerTests.cs
    [TestMethod]
    public void SetFirstName_SetsName_String()
    {
      string name = "chris";
      Customer newCustomer = new Customer(name, "last", 1, "email"," address", "city", "state", 3, 0);
      string updatedName = "Dan";
      newCustomer.SetFirstName(updatedName);
      string result = newCustomer.GetFirstName();
      Assert.AreEqual(updatedName, result);
    }

#### Customer.cs
<sup>The code block below is written to **pass**</sup>

    public void SetFirstName(string newName)
     {
      _firstName = newName;
    }
To **fail** this test set the property that is being updated to another property such as _lastName.

---
## FirstLast_ConcatsFirstAndLastName_String()

This method is used to concat a first and last name together. For example, if _firstName = Chris and _lastName = Rudnicky, then the FirstLast Method will output chris rudnicky.

#### CustomerTests.cs

    [TestMethod]
    public void FirstLast_ConcatsFirstAndLastName_String()
    {
      Customer newCustomer = new Customer("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      string firstLast = "chris rudnicky";
      string result = newCustomer.FirstLast();
      Assert.AreEqual(firstLast, result);
    }

#### Customer.cs

To **fail** this test, return a random string from the method:

    public string FirstLast()
    {
      string firstLast = _firstName + " " + _state;
      return firstLast;
    }

To **pass** this test, return the correct property:

    public string FirstLast()
    {
      string firstLast = _firstName + " " + _lastName;
      return firstLast;
    }

---

## GetAll Tests
### `GetAll_ReturnsEmptyList_ItemList()`
This method is written so we can retrieve a list of Customers from our Database.

#### CustomerTests.cs

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      List<Customer> newCustomerList = new List<Customer> { };
      List<Customer> result = Customer.GetAll();
      CollectionAssert.AreEqual(newCustomerList, result );

#### Customer.cs
To **fail** this  test, the code should return a populated list:

    public static List<Customer> GetAll(){
      List<Customer> allCustomers = new List<Customer> {};
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      allCustomers.Add(newCustomer);
      return allCustomers;
    }

To **pass** this test, the code will connect to our database and will not return a Customer because we have not used our Save method yet, so no Customers can  be saved to the database:

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
       Customer newCustomer = new Customer(customerFirstName, customerLastName, customerPhoneNumber, customerEmail, customerAddress, customerCity, customerState, customerId);
       allCustomers.Add(newCustomer);
     }
     conn.Close();
     if(conn != null)
     {
       conn.Dispose();
     }
     return allItems;
    }

---

## Public Override Bool Equals
This method is very important because it will allow C# to view two identical objects as similar instead of two different objects.




---
## Save Test Methods

We want to be able to save an item to the database, and we want to be able to assign an ID when a Customer is saved. To do this we require SQL commands.

### `Save_SavesToDataBase_CustomerList()`

#### CustomerTests.cs

    [TestMethod]
    public void Save_SavesToDataBase_CustomerList()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      List<Customer> result = Customer.GetAll();
      List<Customer> testList = new List<Customer>{newCustomer};
      CollectionAssert.AreEqual(testList, result);
    }

To **fail** this test don't include code for the save method. this is because voids do not need to return anything.

    public void Save()
    {

    }
