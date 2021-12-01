using Microsoft.AspNetCore.Mvc;

namespace HomeWork9.Controllers
{
    public class CalculatorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}