using System.Collections.Generic;
using System.Linq;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class FlatParkingRateRepository : IFlatParkingRateRepository
    {
        private readonly ASPNETCoreParkingAppContext _db;

        public FlatParkingRateRepository(ASPNETCoreParkingAppContext context)
        {
            _db = context;
        }

        public void CreateNewFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            _db.FlatParkingRates.Add(flatParkingRate);
            _db.SaveChanges();
        }

        public void DeleteFlatParkingRate(int id)
        {
            var rateToDelete = GetFlatParkingRateByID(id);
            _db.FlatParkingRates.Remove(rateToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<FlatParkingRate> GetAllFlatParkingRates()
        {
            return _db.FlatParkingRates.ToList();
        }

        public FlatParkingRate GetFlatParkingRateByID(int id)
        {
            return _db.FlatParkingRates.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void UpdateFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            _db.FlatParkingRates.Update(flatParkingRate);
            _db.SaveChanges();
        }
    }
}