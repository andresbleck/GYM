using Microsoft.AspNetCore.Mvc;

namespace GimnasioMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "¡Bienvenidos a Zeus gimnasio! Nos complace enormemente tenerlos con nosotros...";
            return View();
        }
    }
}
