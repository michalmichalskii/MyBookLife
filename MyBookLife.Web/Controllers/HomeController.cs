using Microsoft.AspNetCore.Mvc;

namespace MyBookLife.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
