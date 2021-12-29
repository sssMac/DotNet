using Microsoft.AspNetCore.Mvc;

namespace HomeWork10.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}