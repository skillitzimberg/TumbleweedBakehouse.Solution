# Customer Class Tests
<sup>_Chris Rudnicky_</sup>

---
## This file contains testing information for the Customer Class Model. Click the links below to learn more about each test.

- [Constructor Instantiation](#CustomerConstructor_CreatesInstanceOfCustomer_Customer)
- [Get Set Tests](#get-set-tests)
- [Creating a full name](#FirstLast_ConcatsFirstAndLastName_String)
- [GetAll Returning Empty List](#GetAll-Tests)
- [Equality Override Testing](#public-override-bool-equals)
- [Save](#save-test-methods)
- [Find](#find)
- [Edit](#Edit)

### Controller Tests

- [Returning a Correct View](#controller-returns-the-correct-view)
- [Displaying the Correct Model Type](#controller-has-the-correct-model-type)
- [Redirecting to the Correct Action](#controller-redirects-to-the-correct-action)
---

# Model Tests

## Constructor Instantiation

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

#### Customer.cs
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

To test this method we only need to manipulate the ! in the if conditional:
- Removing the ! will fail the test.
- Keeping the ! will pass the test.

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

To ** pass** this test write the following code:

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

### Save_AssignsIdToObject_Id()

#### CustomerTests.cs

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
      newCustomer.Save();
      Customer savedCustomer = Customer.GetAll()[0];
      int result = savedCustomer.GetId();
      int testId = newCustomer.GetId();
      Assert.AreEqual(result, testId);
    }

 To **fail** this test, we can remove the line of code in the  _Customer.cs_ file that reads:
  - `_id=(int)cmd.LastInsertedId;`  

To **pass** this test, replace the above statement in the production code.

 ---
## Find
The find method uses an Id to search through the database to match with an identical id. All columns are then returned.

#### CustomerTests.cs

    [TestMethod]
      public void Find_ReturnsCorrectCustomerFromDatabase_Customer()
      {
        Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
        newCustomer.Save();
        Customer foundCustomer = Customer.Find(newCustomer.GetId());
        Assert.AreEqual(newCustomer, foundCustomer);
      }

#### Customer.cs

    public static Customer Find(int id){
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM customers WHERE id = (@thisId);";
      cmd.Parameters.AddWithValue("@thisId", id);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int customerId = 0;
      string customerFirstName = "";
      string customerLastName = "";
      string customerPhoneNumber = "";
      string customerEmail = "";
      string customerHomeAddress = "";
      string customerCity = " ";
      string customerState = " ";
      int customerZip = 0;
      while (rdr.Read())
      {
         customerId = rdr.GetInt32(0);
         customerFirstName = rdr.GetString(1);
         customerLastName = rdr.GetString(2);
         customerPhoneNumber = rdr.GetString(3);
         customerEmail = rdr.GetString(4);
         customerHomeAddress = rdr.GetString(5);
         customerCity = rdr.GetString(6);
         customerState = rdr.GetString(7);
        customerZip = rdr.GetInt32(8);
      }
      Customer foundCustomer = new Customer(customerFirstName, customerLastName, customerPhoneNumber, customerEmail, customerHomeAddress, customerCity, customerState, customerZip, customerId);
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return foundCustomer;
    }

To **fail** this test switch the columns you return data from in the while loop. For example you could do this:
  >Original:  `customerId = rdr.GetInt32(0);` and `customerZip = rdr.GetInt32(8);`


  >Failing:`customerId = rdr.GetInt32(8);` and `customerZip = rdr.GetInt32(0);`

To **pass** this test change the values in the while loop to return their actual column  

 ---
 ## Edit
The edit method will allow a user to update any property of a customer.
 #### Customer.cs

     public void Edit(string firstName, string lastName, string phoneNumber, string email, string address, string city, string state, int zip){
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE customers SET  firstName = @newFirstName, lastName = @newLastName, phoneNumber = @newPhoneNumber, email = @newEmail, address = @newAddress, city = @newCity, state = @newState, zipcode = @newZipcode WHERE id = @searchId;";
          cmd.Parameters.AddWithValue("@searchId", _id);
          cmd.Parameters.AddWithValue("@newFirstName", firstName);
          cmd.Parameters.AddWithValue("@newLastName", lastName);
          cmd.Parameters.AddWithValue("@newPhoneNumber", phoneNumber);
          cmd.Parameters.AddWithValue("@newEmail", email);
          cmd.Parameters.AddWithValue("@newAddress", address);
          cmd.Parameters.AddWithValue("@newCity",city);
          cmd.Parameters.AddWithValue("@newState",state);
          cmd.Parameters.AddWithValue("@newZipcode", zip);
          cmd.ExecuteNonQuery();
          _firstName = firstName;
          _lastName = lastName;
          _phoneNumber = phoneNumber;
          _email = email;
          _homeAddress = address;
          _city = city;
          _state = state;
          _zipCode = zip;
          conn.Close();
          if (conn !=null)
          {
            conn.Dispose();
          }
        }

#### CustomerTests.cs

    [TestMethod]
        public void Edit_UpdatesCustomerInDataBase_StringandInt()
        {
          Customer newCustomer = new Customer ("chris", "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
          newCustomer.Save();
          string newString ="jake";
          newCustomer.Edit(newString, "rudnicky", "7575640970", "email", "address", "city", "state" , 23188);
          string result = Customer.Find(newCustomer.GetId()).GetFirstName();
          Assert.AreEqual(newString, result);
        }

  To ** fail** this test we could change the value that is being added during the AddWithValue() method. For example if we target:
- `   cmd.Parameters.AddWithValue("@newFirstName", firstName);
`   

We can change _firstName_ to _lastName_ so that it looks like this:
- `   cmd.Parameters.AddWithValue("@newFirstName", lastName);
`   

The test will now fail. To pass this test return the value to what it ought to be.

---

# Controller Tests

## Controller Returns the Correct View

All controllers will be tested to see if they return the correct type of view. It can be safely assumed that each controller route was tested, however due to the number of controllers being tested I will only include one example of this test.

#### CustomerControllerTests.cs

    [TestMethod]
    public void New_ReturnsCorrectView_True()
      {
        CustomerController controller = new CustomerController();
        ActionResult newView = controller.New();
        Assert.IsInstanceOfType(newView,typeof(ViewResult));
      }


#### CustomerController.cs
To **fail** this test we want the controller to return the incorrect view. To do this we will have the controller return a `new EmptyResult()`. EmptyResults are a representation of an ActionResult that does nothing. As such our test should compile and fail.

    [HttpGet("/customer/{customerId}/new")]
    public ActionResult New()
    {
      return new EmptyResult();
    }

To **pass** this test we want the controller to return a `View()`; which is a type of action result that renders a view to the response.

---
## Controller Has the Correct Model Type

All controllers will be tested to see if they have the correct model type. It can be safely assumed that each controller route was tested, however due to the number of controllers being tested I will only include one example of this test.

#### CustomerControllerTests.cs

_An important note about this test is that you must pass an integer in because the edit method takes an integer_

    [TestMethod]
    public void Edit_HasCorrectModelType_Dictionary()
    {
      ViewResult editView = new CustomerController().Edit(1) as ViewResult;
      var result = editView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

#### CustomerController.cs

    [HttpGet("/customer/{customerId}/edit")]
    public ActionResult Edit(int customerId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Customer customer = Customer.Find(customerId);
      model.Add("customer", customer);
      return View(model);
    }
<sup>_Note the parameter that this controller takes. Remember to pass an integer into the edit method call in the test file to avoid compilation errors_</sup>

To **fail** this test set the return value to any datatype that is not a Dictionary<string, object>. eg:  
  - `return View(0);`

To **pass** this test set the return value to the intended object. In this case:
- `return View(model);`

---
## Controller Redirects To The Correct Action

This test is run on any View file that passes data to another View file. Due to the similarity between each controller route that is tested, I will only use one example of this test. It can be safely assumed that all controllers that pass data to a separate page will be tested the same way.

#### CustomerControllerTests.cs
    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      CustomerController controller = new CustomerController();
      ActionResult view = controller.Create("Ty","Butts","123123312234", "google@gmail.com", "Some road somewhere", "Portland", "Maine", 22030);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

#### CustomerController.cs

    [HttpPost("/customer/{customerId}")]
    public ActionResult Create(string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
    {
      Customer newCustomer = new Customer(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
      newCustomer.Save();
      return RedirectToAction("index");
    }

<sup>Note that the route address for this controller is the same as the one in the [Edit](#controller-has-the-correct-model-type) method above. The difference is the **HttpPost** and the **HttpGet**. Post action methods redirecet information from one page to another.</sup>

The code above will **pass** the test because it `Create()` returns a View.  
 This test seems awful similar to returning a correct view....  
To **fail** this test we can return a `new EmptyResult()`.
