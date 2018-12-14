using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("/product")]
        public ActionResult Index()
        {

          List<Product> productList = Product.GetAll();

          List<Product> newList = new List<Product>{};
          newList = Product.GetAll();

          return View(newList);
        }

        [HttpGet("/product/new")]
        public ActionResult New()
        {
          return View();
        }

        [HttpPost("/product")]
        public ActionResult Create(string name, string type, string description, string  url, bool availability, float price)
        {
          Product newProduct = new Product (name, type, description, url, availability, price);

          return View("show",newProduct);

        }

        [HttpGet("product/{id}")]
        public ActionResult Show(int id)
        {
          Product thisProduct = Product.Find(id);

          return View(thisProduct);
        }

        [HttpGet("product/new")]
        public ActionResult New()
        {
          return View();
        }

        [HttpPost("/product")]
        public ActionResult Create(string name, string type, string description, bool available, float price)
        {
          Product newProduct = new Product (name,type,description,"url",available,price);
          newProduct.Save();
          return RedirectToAction("Index");

        }

    }
}
