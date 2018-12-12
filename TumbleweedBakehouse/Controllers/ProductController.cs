using Microsoft.AspNetCore.Mvc;

namespace ValleyBread.Controllers
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
