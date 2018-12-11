using Microsoft.AspNetCore.Mvc;

namespace ValleyBread.Controllers
{
    public class YourClassController : Controller
    {
        [HttpGet("/yourclass")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
