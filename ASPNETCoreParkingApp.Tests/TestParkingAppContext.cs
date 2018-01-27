using System;
using ASPNETCoreParkingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Tests
{
    public class TestParkingAppContext : ParkingAppContext
    {
        public TestParkingAppContext() : base(null)
        {
            FlatParkingRates = new TestFlatParkingRateDbSet();
            HourlyRates = new TestHourlyRateDbSet();
            DailyRates = new TestDailyRateDbSet();
        }

        public DbSet<FlatParkingRate> FlatParkingRates { get; set; } 

        public DbSet<HourlyRate> HourlyRates { get; set; }

        public DbSet<DailyRate> DailyRates { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(FlatParkingRate rate) { }
        public void Dispose() { }
    }
}