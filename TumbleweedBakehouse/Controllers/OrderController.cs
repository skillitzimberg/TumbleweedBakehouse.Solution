using Microsoft.AspNetCore.Mvc;

namespace ValleyBread.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/yourclass")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
