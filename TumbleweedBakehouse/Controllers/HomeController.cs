using Microsoft.AspNetCore.Mvc;

namespace TumbleweedBakehouse.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
