using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
