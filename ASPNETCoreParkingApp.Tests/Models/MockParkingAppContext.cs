using ASPNETCoreParkingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASPNETCoreParkingApp.Tests.Models
{
    public class MockParkingAppContext : ParkingAppContext
    {
        public MockParkingAppContext() : base(null)
        {
                
        }

        public DbSet<FlatParkingRate> FlatParkingRates => throw new NotImplementedException();

        public DbSet<HourlyRate> HourlyRates => throw new NotImplementedException();

        public DbSet<DailyRate> DailyRates => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
