using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Conditions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ASPNETCoreParkingApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // POST: Calculate
        [HttpPost, ActionName("Calculate")]
        public async Task<IActionResult> Calculate(Parking parking)
        {
            // Get the values
/*            var calculatorFactory = new ParkingCalculatorFactory();
            var calculator = calculatorFactory.GetParkingCalculator(parking);
            var charge = calculator.Charge(parking);
*/
            // Do the calculation

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
