using ASPNETCoreParkingApp.Models;
using System.Linq;

namespace StoreApp.Tests
{
    class TestHourlyRateDbSet : TestDbSet<HourlyRate>
    {
        public override HourlyRate Find(params object[] keyValues)
        {
            return this.SingleOrDefault(rate => rate.ID == (int)keyValues.Single());
        }
    }
}