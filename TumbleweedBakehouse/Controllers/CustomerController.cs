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
          List<Customer> allCustomers = Customer.GetAll();
          return View(allCustomers);
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
        public ActionResult Update(string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
        {
          Customer newCustomer = new Customer(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
          newCustomer.Save();
          return RedirectToAction("show");
        }

        [HttpGet("/customer/new")]
        public ActionResult New()
        {
          // List<Customer> allCustomers = Customer.GetAll();
          return View();
        }
        [HttpPost("/customer")]
        public ActionResult Create(string firstName, string lastName, string phoneNumber, string email, string homeAddress, string city, string state, int zipCode)
        {
          Customer newCustomer = new Customer(firstName, lastName, phoneNumber, email, homeAddress, city, state, zipCode);
          newCustomer.Save();
          return RedirectToAction("index");
        }

        [HttpGet("/customer/{customerId}")]
        public ActionResult Show(int customerId)
        {
          Dictionary<string, object> model = new Dictionary<string, object> { };
          Customer customer = Customer.Find(customerId);
          model.Add("customer", customer);
          return View(model);
        }
    }
}
