using Microsoft.AspNetCore.Mvc;

namespace TumbleweedBakehouse.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("/yourclass")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
