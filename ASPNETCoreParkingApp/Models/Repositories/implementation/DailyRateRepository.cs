using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class DailyRateRepository : IDailyRateRepository
    {
        private readonly ASPNETCoreParkingAppContext _db;

        public DailyRateRepository(ASPNETCoreParkingAppContext context)
        {
            _db = context;
        }

        public void CreateNewDailyRate(DailyRate dailyRate)
        {
            _db.DailyRates.Add(dailyRate);
            _db.SaveChanges();
        }

        public void DeleteDailyRate(int id)
        {
            var rateToDelete = GetDailyRateByID(id);
            _db.DailyRates.Remove(rateToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<DailyRate> GetAllDailyRates()
        {
            return _db.DailyRates.ToList();
        }

        public DailyRate GetDailyRateByID(int id)
        {
            return _db.DailyRates.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void UpdateDailyRate(DailyRate dailyRate)
        {
            _db.DailyRates.Update(dailyRate);
            _db.SaveChanges();
        }
    }
}
