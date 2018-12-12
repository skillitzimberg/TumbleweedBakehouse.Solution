using Microsoft.AspNetCore.Mvc;

namespace TumbleweedBakehouse.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/yourclass")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
