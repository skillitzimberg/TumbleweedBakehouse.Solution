using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/order/{customerId}")]
        public ActionResult Index(int customerId)
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            //Customer currentCustomer = Customer.Find(customerId);
            //List<Order> orderList = Order.GetAll();
          return View(model);
        }

        [HttpGet("/order/{customerId}/show/{orderId}")]
        public ActionResult Show()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };

            return View(model);
        }

        [HttpGet("/order/{customerId}/new")]
        public ActionResult New()
        {

            return View();
        }
    }
}
