using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TumbleweedBakehouse.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/order")]
        public ActionResult Index()
        {
          return View();
        }

        [HttpGet("/order/{customerId}")]
        public ActionResult Show()
        {
            Dictionary<string, object> model = new Dictionary<string, object> { };
            
            return View(model);
        }
    }
}
