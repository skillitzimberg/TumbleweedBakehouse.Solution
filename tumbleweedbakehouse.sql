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
(10, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(11, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(12, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(13, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(14, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(15, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(16, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(17, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(18, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(19, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(20, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(21, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(22, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(23, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(24, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(25, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(26, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(27, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(28, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(29, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(30, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(31, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(32, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(33, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(34, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(35, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(36, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(37, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(38, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(39, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(40, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(41, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(42, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(43, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(44, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(45, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(46, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(47, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(48, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(49, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(50, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(51, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(52, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(53, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(54, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(55, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(56, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(57, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(58, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(59, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(60, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(61, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(62, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(63, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(64, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(65, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(66, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(67, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(68, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(69, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(70, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(71, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(72, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(73, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(74, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(75, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(76, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(77, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(78, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(79, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(80, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(81, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(82, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(83, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(84, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(85, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(86, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(87, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(88, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(89, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(90, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(91, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(92, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(93, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(94, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(95, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(96, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(97, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(98, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(99, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(100, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(101, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(102, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(103, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(104, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(105, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(106, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(107, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(108, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(109, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(110, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(111, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(112, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(113, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(114, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(115, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(116, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(117, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(118, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(119, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(120, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(121, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(122, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(123, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(124, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(125, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(126, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(127, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(128, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(129, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(130, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(131, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(132, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(133, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(134, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(135, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(136, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(137, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(138, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(139, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(140, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(141, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(142, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(143, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(144, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(145, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(146, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(147, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(148, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(149, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(150, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(151, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(152, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(153, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(154, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(155, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(156, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(157, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(158, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(159, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(160, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(161, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(162, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(163, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(164, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(165, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(166, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(167, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(168, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(169, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(170, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(171, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(172, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(173, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(174, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(175, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(176, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(177, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(178, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(179, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(180, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(181, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(182, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(183, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(184, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(185, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(186, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(187, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(188, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(189, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(190, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(191, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(192, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(193, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(194, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(195, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(196, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(197, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(198, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(199, 'sourdough', 'light and fluffy', 1, 3, 'raye', '/img/Challah.jpg'),
(200, 'Honeybread', 'hearty and sweet', 1, 5, 'Wheat', '/img/Challah.jpg'),
(201, 'Round Challah', 'Knotty & nice', 0, 4, 'sweet breads', '/img/RoundChallah.jpg');

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
