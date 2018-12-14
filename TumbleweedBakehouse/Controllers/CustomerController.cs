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
        [HttpGet("/customer/{customerId}/edit")]
        public ActionResult Edit()
        {
          return View();
        }
        [HttpGet("/customer/{customerId}/new")]
        public ActionResult New()
        {
          return View();
        }
        [HttpGet("/customer/{customerId}/")]
        public ActionResult Show()
        {
          return View();
        }
    }
}
