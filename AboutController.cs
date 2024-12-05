using Microsoft.AspNetCore.Mvc;

namespace GimnasioMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }

}
