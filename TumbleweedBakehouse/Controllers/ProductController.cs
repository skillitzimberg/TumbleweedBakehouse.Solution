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

          return View(productList);
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
