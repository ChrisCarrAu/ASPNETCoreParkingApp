using System.Collections.Generic;

namespace ASPNETCoreParkingApp.Models.Repositories.interfaces
{
    public interface IDailyRateRepository
    {
        void CreateNewDailyRate(DailyRate dailyRate);
        void DeleteDailyRate(int id);
        DailyRate GetDailyRateByID(int id);
        IEnumerable<DailyRate> GetAllDailyRates();
        int SaveChanges();
    }
}
