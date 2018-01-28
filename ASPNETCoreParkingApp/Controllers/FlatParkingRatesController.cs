using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreParkingApp.Controllers
{
    //[HandleError]
    public class FlatParkingRatesController : Controller
    {
        /// <summary>
        /// Repository abstracts away the model
        /// </summary>
        private readonly IFlatParkingRateRepository _repository;

        /// <summary>
        /// Default controller creates a default repository
        /// </summary>
        public FlatParkingRatesController(IFlatParkingRateRepository repository)
        {
            _repository = repository;
        }

        // GET: FlatParkingRates
        public async Task<IActionResult> Index()
        {
            return View(_repository.GetAllFlatParkingRates()); //  await db.FlatParkingRates.ToListAsync());
        }

        // GET: FlatParkingRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            FlatParkingRate flatParkingRate = _repository.GetFlatParkingRateByID((int)id); // await db.FlatParkingRates.FindAsync(id);
            if (flatParkingRate == null)
            {
                return new NotFoundResult();
            }
            return View(flatParkingRate);
        }

        // GET: FlatParkingRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlatParkingRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "ID, Description, EntryTimeStart, EntryTimeEnd, ExitTimeStart, ExitTimeEnd, EntryDays, Charge")] FlatParkingRate flatParkingRate)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateNewFlatParkingRate(flatParkingRate);
                return RedirectToAction("Index");
            }

            return View(flatParkingRate);
        }

        // GET: FlatParkingRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            FlatParkingRate flatParkingRate = _repository.GetFlatParkingRateByID((int)id);  // await db.FlatParkingRates.FindAsync(id);
            if (flatParkingRate == null)
            {
                return new NotFoundResult();
            }
            return View(flatParkingRate);
        }

        // POST: FlatParkingRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: "ID, Description, EntryTimeStart, EntryTimeEnd, ExitTimeStart, ExitTimeEnd, EntryDays, Charge")] FlatParkingRate flatParkingRate)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateFlatParkingRate(flatParkingRate);
                return RedirectToAction("Index");
            }
            return View(flatParkingRate);
        }

        // GET: FlatParkingRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            FlatParkingRate flatParkingRate = _repository.GetFlatParkingRateByID((int) id); //  await db.FlatParkingRates.FindAsync(id);
            if (flatParkingRate == null)
            {
                return new NotFoundResult();
            }
            return View(flatParkingRate);
        }

        // POST: FlatParkingRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            FlatParkingRate flatParkingRate = _repository.GetFlatParkingRateByID((int) id); // await db.FlatParkingRates.FindAsync(id);
            _repository.DeleteFlatParkingRate(id);
            return RedirectToAction("Index");
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
