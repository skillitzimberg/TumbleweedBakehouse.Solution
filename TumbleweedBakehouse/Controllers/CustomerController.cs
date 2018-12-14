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
        [HttpPost("/customer/{customerId}")]
        public ActionResult Create(string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
        {
          Customer newCustomer = new Customer(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
          newCustomer.Save();
          List<Customer> allCustomers = Customer.GetAll();
          return View("index", allCustomers);
          // return new EmptyResult();
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
