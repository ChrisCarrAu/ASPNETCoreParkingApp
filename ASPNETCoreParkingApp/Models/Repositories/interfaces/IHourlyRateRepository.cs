using System.Collections.Generic;

namespace ASPNETCoreParkingApp.Models.Repositories.interfaces
{
    public interface IHourlyRateRepository
    {
        void CreateNewHourlyRate(HourlyRate hourlyRate);
        void DeleteHourlyRate(int id);
        HourlyRate GetHourlyRateByID(int id);
        IEnumerable<HourlyRate> GetAllHourlyRates();
        void UpdateHourlyRate(HourlyRate hourlyRate);
        int SaveChanges();
    }
}
