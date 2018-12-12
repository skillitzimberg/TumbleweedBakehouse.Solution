# Planning Document
# Valley Bread
Create an MVC web application order/customer/product tracking app.

## User Stories
Salon employees should to be able to:
* VIEW ALL CUSTOMERS
* VIEW CUSTOMER CONTACT LIST
* ADD CUSTOMER
* FIND CUSTOMER
* VIEW CUSTOMER DETAILS
* VIEW LIST OF ALL CUSTOMER ORDERS
* ADD PRODUCT TO ORDER
* TRACK SALES OF INDIVIDUAL PRODUCTS
* VIEW SALES TRENDS OVER THE COURSE OF A MONTH/YEAR
* COSTING FOR INGREDIENTS
* COSTING FOR SUPPLIES, GAS, ETC.
* GROSS PROFITS
* SHOW/HIDE AVAILABLE PRODUCTS

## Products
Demi Baguettes  
Spelt Sourdough  
Chile Cheddar Sourdough  
Challah  
Cinnamon Raisin Swirl  
Apple Walnut Sourdough  
Light Brioche  
Flax Oatmeal  
Seedy Sourdough  
Roasted Garlic Sourdough  
Turmeric Onion Sourdough  
Blue Corn Anadama  
Country Sour  
Honey Whole Wheat  
Chocolate & Red Chile Flake Sourdough  
Semolina Rolls  
Pumpernickel  
Hot Cross Buns  

### Classes
* ORDERS
* CUSTOMERS
* PRODUCTS

### Orders database columns/class properties
- id: PRIMARY KEY, AUTO_INCREMENT
- order_number
- product
- product_qty
- order_received_date
- order_delivered_date
- customer_id: FOREIGN KEY


### Customer database columns/class properties
- id: PRIMARY KEY, AUTO_INCREMENT
- first_name
- last_name
- phone_number
- email
- address

### Products database columns/class properties
- id: PRIMARY KEY, AUTO_INCREMENT
- name
- type
- price
- description

## Models/Methods
### Customer
- public int GetId()
- public string GetFirstName()
- public string GetLastName()
- public string GetFullName()
- public string GetPhoneNumber()
- public string GetEmail()
- public List<Customer> GetAll()
- public void Save()
- public Customer Find(int id)

**FOR TESTING HOUSEKEEPING:**
- public override bool Equals(System.Object otherCustomer)
- public void ClearAll()

### Order
- public int GetId()
- public List<Order> GetAll()
- public void Save()
- public Order Find(int id)
- public List<Customer> GetCustomer()

**FOR TESTING HOUSEKEEPING:**
- public override bool Equals(System.Object otherOrder)
- public void ClearAll()

### HomeController
[HttpGet("/")] Index()

### CustomerController
[HttpGet("/customers")] Index() - @Model: none  
[HttpGet("/customers/new")] New(int orderId) - @Model: none  
[HttpPost("/customers")] Create() - @Model: Dictionary<string, object>  
[HttpGet("/customers/show")] Show(int id) - @Model: Dictionary<string, object>

### OrderController
[HttpGet("/orders")] Index() - @Model: none  
[HttpGet("/orders/new")] New() - @Model: none  
[HttpPost("/orders")] Create() - @Model: Dictionary<string, object>  
[HttpGet("/orders/show")] Show(int id) - @Model: Dictionary<string, object>  

#### GENERAL STEPS TAKEN
Outline Classes/Tables  
Outline Models/Methods  
Write Specs  
Create Database/tables  
Create Test Database  
Export Database  
Add Exported Database to ValleyBread.Solution folder  
Create Models folder  
Create .cs file for each Class in Models folder  
Create ControllerTest file for each Class and Home  
Create ModelTests folder  
Create Test Files for each Class in the ModelTests folder  
Create basic content for all files  
Set up test files for working with the database  
Test that class properties can be retrieved  
Implement teardown using Dispose() and ClearAll() so that test data is cleared between each test  
Add Equals() method to type cast objects, "customers" in this case, that are in different parts of memory - one in RAM, one from the database - as the same object.  
Test that Save() saves to Database & GetAll() gets all customers.  

###  Specs
#### Customer Model Specs
##### 1: CustomerConstructor returns Customer
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: Customer - Scott Bergler

##### 2: Customer returns customer id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1

##### 3: Customer returns customer first name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Scott"

##### 4: Customer returns customer last name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Bergler"

##### 5: Customer returns customer phone numbe
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "5038905118"

##### 6: Customer returns order id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1

##### 7: Customer returns empty list
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2)  
Output: List<Customer>{}

##### 8: Customer saves to database
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2)  
Output: List<Customer>{customerOne, customerTwo}

##### 9: Customer returns a list of all customers
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2)  
Output: List<Customer>{customerOne, customerTwo}

##### 10: Customer database assigns id
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2)  
Output: 2

#### Find()
##### 11: Customer finds customer
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2)   
Output: Customer - Millicent Zimdars

#### Order Model Specs
##### 12: OrderConstructor returns Order
**Example:**  
Input:  "Stephan", "Blair", 1  
Output: Order - Stephan Blair

##### 13: Order returns order id
**Example:**  
Input:  "Stephan", "Blair", 1  
Output: 1

##### 14: Order returns order first name
**Example:**  
Input:  "Stephan", "Blair", 1  
Output: "Scott"

##### 15: Order returns order last name
**Example:**  
Input:  "Stephan", "Blair", 1  
Output: "Blair"

##### 16: Order returns empty list
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)  
Output: List<Order>{}

##### 17: Order clears database
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)  
Output: List<Order>{}

##### 18: Order saves to database
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)  
Output: List<Order>{orderOne, orderTwo}

##### 19: Order adds new order
**Example:**  
Input: orderOne: ("Stephan", "Blair", 1)  
Output: List<Order>{orderOne}

##### 20: Order database assigns id
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1, 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: 2

##### 21: Order returns a list of all orders
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)  
Output: List<Order>{orderOne, orderTwo}

##### 22: Order finds order
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)    
Output: Customer - Stephan Blair

##### 23: Order adds new customer to order roster
**Example:**  
Input:  
orderOne: ("Stephan", "Blair", 1),  
customerOne: ("Scott", "Bergler", "5038905118", 1, 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)
Output: List<Customer>{customerOne, customerTwo}

<!-- These specs may come into play in a later version:
##### 24: Order deletes a order
**Example:**  
Input:
orderOne: ("Stephan", "Blair", 1),  
orderTwo: ("Holly", "Kindred", 1)  
Output: "Holly", "Kindred", 1
##### 25: Order deletes a customer
**Example:**  
Input:
customerOne: ("Scott", "Bergler", "5038905118", 1, 1),  
customerTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: "Millicent", "Zimdars", "5034217832", 2, 1 -->

### Order Controller Specs
##### 24: Index Returns Correct View
**Example:**  
Input:  indexView  
Output: true

##### 25: Index Returns Correct Model Datatype
**Example:**  
Input:  modelDatatype  
Output: true

##### 26: New Returns Correct View
**Example:**  
Input:  newView  
Output: true

##### 27: Create Order Returns Correct View
**Example:**  
Input:  "Mindy", "StCyr"  
Output: true

##### 28: Create Order Redirects To Correct View
**Example:**  
Input:  "Mindy", "StCyr"  
Output: true

##### 29: Show Returns Correct View
**Example:**  
Input:  "Wes", "Cecil"  
Output: true

##### 30: Create Customer  Returns Correct Action Name
**Example:**  
Input:  "Wes", "Cecil", testOrder.GetId(), "Scott", "Bergler", "5038905118"  
Output: true

##### 31: Create Customer Returns Correct Model Datatype
**Example:**  
Input:  "Wes", "Cecil", testOrder.GetId(), "Scott", "Bergler", "5038905118"  
Output: true

### Customer Controller Specs
##### 32: New Returns Correct View
**Example:**  
Input:  New() view  
Output: true

##### 33: Show Returns Correct View
**Example:**  
InputOne:  testOrder = new Order("Wes", "Cecil")  
InputTwo:  testCustomer = new Customer("Scott", "Bergler", "5038905118",   testOrder.GetId())
Output: true

### Additional Specs
##### 34: Customer returns customer full name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Scott Bergler"

##### 34: Order returns order full name
**Example:**  
Input:  "Mindy", "StCyr"  
Output: "Mindy StCyr"
