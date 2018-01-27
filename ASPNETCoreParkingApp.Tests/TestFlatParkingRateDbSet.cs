using ASPNETCoreParkingApp.Models;
using System.Linq;

namespace StoreApp.Tests
{
    class TestFlatParkingRateDbSet : TestDbSet<FlatParkingRate>
    {
        public override FlatParkingRate Find(params object[] keyValues)
        {
            return this.SingleOrDefault(rate => rate.ID == (int)keyValues.Single());
        }
    }
}