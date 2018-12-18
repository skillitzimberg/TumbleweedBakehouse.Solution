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

        [HttpGet("/market")]
        public ActionResult Market()
        {
          return View();
        }

    }
}
