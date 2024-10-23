using LAB2_SIWON.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB2_SIWON.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        ///Calculator/Result?x=2&operator=add&y=3

        public IActionResult Form()
        {
            return View();
        }
        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

        // PO STWORZENIU MODELU
        //W metodzie wskazano, które dane żądania powinny utworzyć model.
        //Atrybut [FromForm] wskazuje, że model
        //typu Calculator powinien zostać utworzony na podstawie
        //ciała żądania, w którym są dane z formularza
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            //double wynik = model.Calculate();  
           // ViewBag.Result = wynik;  
            return View(model);
        }
        //PRZED UZYCIEM MODELU
        /*
        public IActionResult Result(Operator op, double? a, double? b)
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
        */
    }
}
