using HomeWork8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork8.Controllers
{
    public class CalculatorController : Controller
    {
        
        [HttpGet]
        public IActionResult Add([FromServices] ICalculator calculator, double v1, double v2)
        {
            return Ok(calculator.Add(v1, v2));
        }
        
        [HttpGet]
        public IActionResult Min([FromServices] ICalculator calculator, double v1, double v2)
        {
            return Ok(calculator.Min(v1, v2));

        }
        
        [HttpGet]
        public IActionResult Div([FromServices] ICalculator calculator, double v1, double v2)
        {
            return Ok(calculator.Div(v1, v2));

        }
        
        [HttpGet]
        public IActionResult Mul([FromServices] ICalculator calculator, double v1, double v2)
        {
            return Ok(calculator.Mul(v1, v2));

        }
        
        
    }
}