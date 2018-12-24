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

        [HttpGet("order/{orderId}")]
        public ActionResult Show(int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            List<Order> orderList = Order.GetAll();
            List<Product> orderInventory = Order.Find(orderId).GetProductsInOrder();
            List<Product> productList = Product.GetAll();
            model.Add("thisOrder", Order.Find(orderId));
            model.Add("orderInventory", orderInventory);
            model.Add("orders", orderList);
            model.Add("products", productList);
            return View(model);
        }

        [HttpGet("/order/{orderId}/edit")]
        public ActionResult Edit(int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            Order newOrder = Order.Find(orderId);
            List<Product> orderInventory = newOrder.GetProductsInOrder();
            List<Product> allProducts = Product.GetAll();
            model.Add("order", newOrder);
            model.Add("orderInventory", orderInventory);
            model.Add("products", allProducts);
            return View(model);
        }

        [HttpPost("/order/{orderId}")]
        public ActionResult Update(int orderId, int orderNumber, int customerId, DateTime requestedPickupDate, DateTime deliveredDate, string pickupLocation, int[] productId, int[] qty, int[] newProductId, int[] newQty)
        {
            Order updatedOrder = Order.Find(orderId);
            updatedOrder.Edit(requestedPickupDate, deliveredDate, pickupLocation);

            for (int i = 0; i < productId.Length; i++)
            {
                if (qty[i] != 0)
                {
                    updatedOrder.UpdateProductQTYinOrder(productId[i], qty[i]);
                }
                else if (qty[i] == 0)
                {
                    updatedOrder.RemoveProductFromOrder(productId[i]);
                }
            }
            for (int j = 0; j < newProductId.Length; j++)
            {
                int currentProductQty = updatedOrder.GetProductsQTYInOrder(newProductId[j]);

                if (newQty[j] != 0 && currentProductQty == 0 )
                {
                    updatedOrder.AddProductToOrder(Product.Find(newProductId[j]), newQty[j]);
                }
                else if (newQty[j] != 0 && currentProductQty > 0)
                {
                    updatedOrder.UpdateProductQTYinOrder(newProductId[j], currentProductQty + newQty[j]);
                }
            }

            return RedirectToAction("Show", new { orderId = orderId});
        }
    }
}
