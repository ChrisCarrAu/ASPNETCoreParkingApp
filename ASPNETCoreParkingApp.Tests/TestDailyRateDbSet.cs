using ASPNETCoreParkingApp.Models;
using System.Linq;

namespace StoreApp.Tests
{
    class TestDailyRateDbSet : TestDbSet<DailyRate>
    {
        public override DailyRate Find(params object[] keyValues)
        {
            return this.SingleOrDefault(rate => rate.ID == (int)keyValues.Single());
        }
    }
}