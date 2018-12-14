CREATE DATABASE tumbleweedbakehouse;  

CREATE TABLE tumbleweedbakehouse.customers ( id INT NOT NULL AUTO_INCREMENT, firstName VARCHAR(255) NOT NULL, lastName VARCHAR(255) NOT NULL, phoneNumber VARCHAR(255) NOT NULL, email VARCHAR(255) NOT NULL, address VARCHAR(255) NOT NULL, city VARCHAR(255) NOT NULL,  state VARCHAR(255) NOT NULL,  zipcode INT NOT NULL,  PRIMARY KEY (id)) ENGINE = InnoDB;  

CREATE TABLE tumbleweedbakehouse.orders ( id INT NOT NULL AUTO_INCREMENT, orderNumber INT NOT NULL, receivedDate DATETIME NOT NULL, requestedPickupDate DATETIME NOT NULL, deliveredDate DATETIME NOT NULL, pickupLocation VARCHAR(255) NOT NULL, customer_id INT NOT NULL, PRIMARY KEY (id)) ENGINE = InnoDB;

CREATE TABLE tumbleweedbakehouse.products ( id INT NOT NULL AUTO_INCREMENT , Name VARCHAR(255) NOT NULL, description VARCHAR(255) NOT NULL, availability TINYINT(1) NOT NULL, price FLOAT NOT NULL, producttype VARCHAR(255) NOT NULL, PRIMARY KEY (id)) ENGINE = InnoDB;

CREATE DATABASE tumbleweedbakehouse_test;  

CREATE TABLE tumbleweedbakehouse_test.customers ( id INT NOT NULL AUTO_INCREMENT, firstName VARCHAR(255) NOT NULL, lastName VARCHAR(255) NOT NULL, phoneNumber VARCHAR(255) NOT NULL, email VARCHAR(255) NOT NULL, address VARCHAR(255) NOT NULL, city VARCHAR(255) NOT NULL,  state VARCHAR(255) NOT NULL,  zipcode INT NOT NULL,  PRIMARY KEY (id)) ENGINE = InnoDB;  

CREATE TABLE tumbleweedbakehouse_test.orders ( id INT NOT NULL AUTO_INCREMENT, orderNumber INT NOT NULL, receivedDate DATETIME NOT NULL, requestedPickupDate DATETIME NOT NULL, deliveredDate DATETIME NOT NULL, pickupLocation VARCHAR(255) NOT NULL, customer_id INT NOT NULL, PRIMARY KEY (id)) ENGINE = InnoDB;

CREATE TABLE tumbleweedbakehouse_test.products ( id INT NOT NULL AUTO_INCREMENT , Name VARCHAR(255) NOT NULL, description VARCHAR(255) NOT NULL, availability TINYINT(1) NOT NULL, price FLOAT NOT NULL, producttype VARCHAR(255) NOT NULL, PRIMARY KEY (id)) ENGINE = InnoDB;
