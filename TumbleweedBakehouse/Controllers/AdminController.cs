using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Controllers
{
  public class AdminController : Controller
  {
    [HttpGet("/admin")]
    public ActionResult Index ()
    {
      return View();
    }
  }
}
