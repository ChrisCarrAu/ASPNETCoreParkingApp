using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreParkingApp.Controllers
{
    public class DailyRatesController : Controller
    {
        private readonly IDailyRateRepository _repository;

        public DailyRatesController(IDailyRateRepository repository) 
        {
            _repository = repository;
        }

        // GET: DailyRates
        public async Task<ActionResult> Index()
        {
            return View(_repository.GetAllDailyRates());
        }

        // GET: DailyRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            DailyRate dailyRate = _repository.GetDailyRateByID((int)id);
            if (dailyRate == null)
            {
                return new NotFoundResult();
            }
            return View(dailyRate);
        }

        // GET: DailyRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            DailyRate dailyRate = _repository.GetDailyRateByID((int)id);
            if (dailyRate == null)
            {
                return new NotFoundResult();
            }
            return View(dailyRate);
        }

        // POST: DailyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(include: "ID,Charge")] DailyRate dailyRate)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateDailyRate(dailyRate);
                return RedirectToAction("Index");
            }
            return View(dailyRate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
