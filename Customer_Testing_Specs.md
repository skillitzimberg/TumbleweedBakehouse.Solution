# Customer Class Tests
<sup>_Chris Rudnciky_</sup>

---
This file contains testing information for the Customer Class Model. Click the links below to learn more about each test.

- [Constructor Instantiation]("#CustomerConstructor_CreatesInstanceOfCustomer_Customer)
- [Get Set Tests](#property-get-set-tests)
- [Creating a full name](#FirstLast_ConcatsFirstAndLastName_String)
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
## FirstLast_ConcatsFirstAndLastName_String
