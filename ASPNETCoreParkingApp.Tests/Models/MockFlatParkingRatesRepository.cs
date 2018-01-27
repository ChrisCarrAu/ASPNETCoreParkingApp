using ASPNETCoreParkingApp.Models;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Tests.Models
{
    /// <summary>
    /// Moc Flat Parking Rate Repository for testing.
    /// </summary>
    public class MockFlatParkingRateRepository : IFlatParkingRateRepository
    {
        private List<FlatParkingRate> _db = new List<FlatParkingRate>();

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(flatParkingRate);
        }

        public void DeleteFlatParkingRate(int id)
        {
            _db.Remove(GetFlatParkingRateByID(id));
        }

        public IEnumerable<FlatParkingRate> GetAllFlatParkingRates()
        {
            return _db.ToList();
        }

        public FlatParkingRate GetFlatParkingRateByID(int id)
        {
            return _db.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void Add(FlatParkingRate flatParkingRate)
        {
            _db.Add(flatParkingRate);
        }

        public void SaveChanges(FlatParkingRate flatParkingRate)
        {
            foreach (var rate in _db)
            {
                if (rate.ID == flatParkingRate.ID)
                {
                    _db.Remove(flatParkingRate);
                    _db.Add(flatParkingRate);
                    break;
                }
            }

        }

        public void UpdateFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            SaveChanges(flatParkingRate);
        }
    }
}
