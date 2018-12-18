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

function Customer(firstName, lastName, phoneNumber, email, address1, address2, state, zip) {
  this.firstName = "";
  this.lastName = "";
  this.phoneNumber = "";
  this.email = "";
  this.address1 = "";
  this.address2 = "";
  this.city = "";
  this.state = "";
  this.zip = 0;
}

Cart.prototype.addCustomer = function(pickupLocation) {
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

// Google Maps: Initialize and add the map
function initMap() {
  // The location of Uluru
  var uluru = {lat: -25.344, lng: 131.036};
  // The map, centered at Uluru
  var map = new google.maps.Map(
      document.getElementById('map'), {zoom: 4, center: uluru});
  // The marker, positioned at Uluru
  var marker = new google.maps.Marker({position: uluru, map: map});
}

$(document).ready(function(){
    $(".productGridItem").click(function(){
      var productName = $( "p#productName" ).text();
      var productPrice = $( "p#productPrice" ).text();
    });
});
