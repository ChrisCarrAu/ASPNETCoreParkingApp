using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreParkingApp.Controllers
{
    public class HourlyRatesController : Controller
    {
        private readonly IHourlyRateRepository _repository;

        /// <summary>
        /// Default controller creates a default repository
        /// </summary>
        public HourlyRatesController(IHourlyRateRepository repository)
        {
            _repository = repository;
        }


        // GET: HourlyRates
        public async Task<ActionResult> Index()
        {
            return View(_repository.GetAllHourlyRates());
        }

        // GET: HourlyRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            HourlyRate hourlyRate = _repository.GetHourlyRateByID((int)id);
            if (hourlyRate == null)
            {
                return new NotFoundResult();
            }
            return View(hourlyRate);
        }

        // GET: HourlyRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HourlyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(include: "ID,HourLimit,Charge")] HourlyRate hourlyRate)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateNewHourlyRate(hourlyRate);
                return RedirectToAction("Index");
            }

            return View(hourlyRate);
        }

        // GET: HourlyRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            HourlyRate hourlyRate = _repository.GetHourlyRateByID((int)id);
            if (hourlyRate == null)
            {
                return new NotFoundResult();
            }
            return View(hourlyRate);
        }

        // POST: HourlyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(include: "ID,HourLimit,Charge")] HourlyRate hourlyRate)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateHourlyRate(hourlyRate);
                return RedirectToAction("Index");
            }
            return View(hourlyRate);
        }

        // GET: HourlyRates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            HourlyRate hourlyRate = _repository.GetHourlyRateByID((int)id);
            if (hourlyRate == null)
            {
                return new NotFoundResult();
            }
            return View(hourlyRate);
        }

        // POST: HourlyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HourlyRate hourlyRate = _repository.GetHourlyRateByID((int)id);
            _repository.DeleteHourlyRate(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
//                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
