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
          Product newProductOne = new Product("sourdough","raye","light and fluffy",true,3,1);
          Product newProductTwo = new Product("Honeybread","Wheat","hearty and sweet",true,5,2);
          List<Product> productList = new List<Product> { newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo, newProductOne, newProductTwo };

          return View(productList);
        }

    }
}
