using System.Collections.Generic;

namespace ASPNETCoreParkingApp.Models.Repositories.interfaces
{
    public interface IFlatParkingRateRepository
    {
        void CreateNewFlatParkingRate(FlatParkingRate flatParkingRate);
        void DeleteFlatParkingRate(int id);
        FlatParkingRate GetFlatParkingRateByID(int id);
        IEnumerable<FlatParkingRate> GetAllFlatParkingRates();
        int SaveChanges();
    }
}
