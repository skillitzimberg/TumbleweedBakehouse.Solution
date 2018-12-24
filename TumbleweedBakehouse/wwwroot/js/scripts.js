function Cart() {
  this.customer = [];
  this.products =[];
  this.pickupLocation = "";
  this.pickupDate = "";
}

function Product() {
  this.name = "";
  this.price = 0;
}

function Customer(firstName, lastName, phoneNumber, email, address1, state, zip) {
  this.firstName = "";
  this.lastName = "";
  this.phoneNumber = "";
  this.email = "";
  this.address1 = "";
  this.city = "";
  this.state = "";
  this.zip = 0;
}

Cart.prototype.addCustomer = function(customer) {
  this.customer.push(customer);
}

Cart.prototype.addProduct = function(product) {
  this.products.push(product);
}

Cart.prototype.setPickupLocation = function(pickupLocation) {
  this.pickupLocation = pickupLocation;
}

Cart.prototype.setPickupDate = function(pickupDate) {
  this.pickupDate = pickupDate;
}

var cart = new Cart();

$(document).ready(function() {

});
