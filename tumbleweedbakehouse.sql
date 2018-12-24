-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 17, 2018 at 01:56 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tumbleweedbakehouse`
--
CREATE DATABASE IF NOT EXISTS `tumbleweedbakehouse` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tumbleweedbakehouse`;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `id` int(11) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL,
  `phoneNumber` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `zipcode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`id`, `firstName`, `lastName`, `phoneNumber`, `email`, `address`, `city`, `state`, `zipcode`) VALUES
(1, 'Scott', 'Bergler', '235-235-3958', 'asfgi@jaweig.com', '2359- 03jwdv', '0cjwe', 'sd', 139),
(2, 'Oingo', 'Elfman', '234-923-2355', 'commandinghands@gmail.com', '6211 NE 11th Ave', 'Portland', 'OR', 97211);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `orderNumber` int(11) NOT NULL,
  `receivedDate` datetime NOT NULL,
  `requestedPickupDate` datetime NOT NULL,
  `deliveredDate` datetime NOT NULL,
  `pickupLocation` varchar(255) NOT NULL,
  `customer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `orderNumber`, `receivedDate`, `requestedPickupDate`, `deliveredDate`, `pickupLocation`, `customer_id`) VALUES
(1, 1, '2018-12-14 17:02:01', '0001-01-01 00:00:00', '0001-01-01 00:00:00', 'La Jara', 1),
(2, 1, '2018-12-14 17:05:29', '0001-01-01 00:00:00', '0001-01-01 00:00:00', 'Alamosa', 2);

-- --------------------------------------------------------

--
-- Table structure for table `orders_customers`
--

CREATE TABLE `orders_customers` (
  `id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `availability` tinyint(1) NOT NULL,
  `price` float NOT NULL,
  `producttype` varchar(255) NOT NULL,
  `url` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `Name`, `description`, `availability`, `price`, `producttype`, `url`) VALUES
(1, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(2, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(3, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(4, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(5, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(6, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(7, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(8, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(9, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(10, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg')

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders_customers`
--
ALTER TABLE `orders_customers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `orders_customers`
--
ALTER TABLE `orders_customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=202;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
