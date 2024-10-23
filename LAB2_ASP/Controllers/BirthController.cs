using LAB2_SIWON.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB2_SIWON.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            //double wynik = model.Calculate();  
            // ViewBag.Result = wynik;  
            return View(model);
        }
    }
}
