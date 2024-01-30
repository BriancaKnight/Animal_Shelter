using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Home - Animal Shelter";
      return View();
    }
  }
}