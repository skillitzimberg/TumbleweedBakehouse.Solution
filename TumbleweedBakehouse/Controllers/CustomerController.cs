using Microsoft.AspNetCore.Mvc;

namespace TumbleweedBakehouse.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/customer")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
