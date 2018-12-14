using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/customer")]
        public ActionResult Index()
        {
          return View();
        }
        [HttpGet("/customer/{customerId}/edit")]
        public ActionResult Edit(int customerId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Customer customer = Customer.Find(customerId);
          model.Add("customer", customer);
          return View(model);
        }
        [HttpGet("/customer/{customerId}/new")]
        public ActionResult New()
        {
          return View();
        }
        [HttpGet("/customer/{customerId}/")]
        public ActionResult Show()
        {
          return View();
        }
    }
}
