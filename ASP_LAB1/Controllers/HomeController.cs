using LAB1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LAB1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public enum Operator
        {
            Unknown,Add, Mul, Sub, Div
        }

        public IActionResult About([FromQuery(Name = "calc-op")] Operator op)
        {
            ViewBag.Op = op;
            return View();
        }
        /*
        public IActionResult About(Operator op)
        {
            ViewBag.Op = op;
            return View();
        }
        */

        
        public IActionResult Calculator(Operator op,double?a,double?b)
        {
            double? result = null;

            if (a.HasValue && b.HasValue)
            {
                switch (op)
                {
                    case Operator.Add:
                        result = a + b;
                        break;
                    case Operator.Sub:
                        result = a - b;
                        break;
                    case Operator.Mul:
                        result = a * b;
                        break;
                    case Operator.Div:
                        if (b != 0)
                            result = a / b;
                        break;
                    default:
                        ViewBag.ErrorMessage = "Nieznany operator";
                        break;
                }
            }

            ViewBag.Op = op;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.Result = result;

            return View();

        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
