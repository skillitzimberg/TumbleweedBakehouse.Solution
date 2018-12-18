using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

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

        [HttpPost("/product/new")]
        public ActionResult New()
        {
          return View();
        }

        [HttpGet("product/{id}")]
        public ActionResult Show(int id)
        {
          Product thisProduct = Product.Find(id);

          return View(thisProduct);
        }

        [HttpPost("/product")]
        public ActionResult Create(string name, string type, string description,IFormFile  img, bool available, float price,int id)
        {
          byte[] newImg = new byte[0];
            if (img != null)
            {
                using (Stream fileStream = img.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    newImg = ms.ToArray();
                }
            }
          Product newProduct = new Product (name,type,description,newImg,available,price,id);
          newProduct.Save();
          return RedirectToAction("Index");

        }

        [HttpGet("/product/{id}/edit")]
        public ActionResult Edit(int id)
        {
          Product editProduct = Product.Find(id);
          return View(editProduct);
      }

        [HttpPost("/product/{productId}")]
        public ActionResult Update(int productId, string name, string type, string description, byte[] img, bool availablity, float price)
        {
          Product product = Product.Find(productId);
        product.Edit(name, type, description, img, availablity, price);
        return RedirectToAction("index", new{id = productId});
        }

    }
}
