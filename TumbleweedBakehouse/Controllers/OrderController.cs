using Microsoft.AspNetCore.Mvc;

namespace TumbleweedBakehouse.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/order")]
        public ActionResult Index()
        {
          return new EmptyResult();
        }

    }
}
