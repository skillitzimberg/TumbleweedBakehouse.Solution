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
          Product newProductOne = new Product("sourdough","raye","light and fluffy","/img/Challah.jpg",true,3,1);
          newProductOne.Save();
          Product newProductTwo = new Product("Honeybread","Wheat","hearty and sweet","/img/Challah.jpg",true,5,2);
          newProductTwo.Save();
          List<Product> productList = Product.GetAll();

          return View(productList);
        }

        [HttpGet("product/{id}")]
        public ActionResult Show(int id)
        {
          Product thisProduct = Product.Find(id);

          return View(thisProduct);
        }

    }
}
