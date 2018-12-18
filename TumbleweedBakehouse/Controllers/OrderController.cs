using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/order/")]
        public ActionResult Index()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Customer> customerList = Customer.GetAll();
            List<Order> orderList = Order.GetAll();
            model.Add("customers", customerList);
            model.Add("orders", orderList);
            return View(model);
        }

        [HttpGet("/order/new")]
        public ActionResult New()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Customer> customerList = Customer.GetAll();
            List<Order> orderList = Order.GetAll();
            List<Product> productList = Product.GetAll();
            model.Add("customers", customerList);
            model.Add("orders", orderList);
            model.Add("products", productList);
            return View(model);
        }

        [HttpPost("/order")]
        public ActionResult Create(int customerId, DateTime requestedPickupDate, string pickupLocation, int[] productId, int[] qty)
        {
            Order newOrder = new Order(1, requestedPickupDate, pickupLocation, customerId);
            newOrder.Save();
            for (int i = 0; i < productId.Length; i++)
            {
                if (qty[i] != 0 && qty[i] != null)
                {
                newOrder.AddProductToOrder(Product.Find(productId[i]), qty[i]);
                }
            }   
            return RedirectToAction("Index");
        }

        [HttpGet("/order/{orderId}/thisOrder")]
        public ActionResult Show(int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Order> orderList = Order.GetAll();
            List<Product> productList = Product.GetAll();
            model.Add("thisOrder", Order.Find(orderId));
            model.Add("orders", orderList);
            model.Add("products", productList);
            //return View(model);
            return new EmptyResult();
        }

        [HttpGet("/order/allCustomers")]
        public ActionResult CustomerIndex(int customerId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            //Customer currentCustomer = Customer.Find(customerId);
            List<Order> orderList = Order.GetAll();
            model.Add("orders",orderList);
            return View(model);
        }

        [HttpGet("/order/{customerId}/show/{orderId}")]
        public ActionResult ShowCustomerOrder(int customerId, int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };

            return View(model);
        }

        [HttpGet("/order/{customerId}/new")]
        public ActionResult NewCustomerOrder(int customerId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };

            return View();
        }
    }
}
