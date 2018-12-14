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

        // [HttpPost("/product/show")]
        // public ActionResult Show()
        // {
        //
        // }




        //
        // Dictionary<string, object> model = new Dictionary<string, object>{};
        // Product selectProduct = Product.Find(id);
        // List<Product> allProducts = Product.GetAll();
        // model.Add("selectProduct",selectProduct);
        // model.Add("allProducts", allProducts);
        //



        // Product newProductOne = new Product("sourdough","raye","light and fluffy","URL",true,3,1);
        // Product newProductTwo = new Product("Honeybread","Wheat","hearty and sweet","URL",true,5,2);
        // List<Product> productList = new List<Product> { newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo };








    }
}
