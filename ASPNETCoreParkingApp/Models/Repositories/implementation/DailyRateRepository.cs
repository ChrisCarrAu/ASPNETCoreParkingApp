using System;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class DailyRateRepository : IDailyRateRepository, IDisposable
    {
        private readonly ParkingAppContext _context;

        public DailyRateRepository(ParkingAppContext context)
        {
            _context = context;
        }

        public void CreateNewDailyRate(DailyRate dailyRate)
        {
            _context.DailyRates.Add(dailyRate);
            _context.SaveChanges();
        }

        public void DeleteDailyRate(int id)
        {
            var rateToDelete = GetDailyRateByID(id);
            _context.DailyRates.Remove(rateToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<DailyRate> GetAllDailyRates()
        {
            return _context.DailyRates.ToList();
        }

        public DailyRate GetDailyRateByID(int id)
        {
            return _context.DailyRates.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateDailyRate(DailyRate dailyRate)
        {
            _context.DailyRates.Update(dailyRate);
            _context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NoteRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
