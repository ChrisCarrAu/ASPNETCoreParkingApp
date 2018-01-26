﻿using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class HourlyRateRepository : IHourlyRateRepository
    {
        private readonly ASPNETCoreParkingAppContext _db;

        public HourlyRateRepository(ASPNETCoreParkingAppContext context)
        {
            _db = context;
        }

        public void CreateNewHourlyRate(HourlyRate hourlyRate)
        {
            _db.HourlyRates.Add(hourlyRate);
            _db.SaveChanges();
        }

        public void DeleteHourlyRate(int id)
        {
            var rateToDelete = GetHourlyRateByID(id);
            _db.HourlyRates.Remove(rateToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<HourlyRate> GetAllHourlyRates()
        {
            return _db.HourlyRates.ToList();
        }

        public HourlyRate GetHourlyRateByID(int id)
        {
            return _db.HourlyRates.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}