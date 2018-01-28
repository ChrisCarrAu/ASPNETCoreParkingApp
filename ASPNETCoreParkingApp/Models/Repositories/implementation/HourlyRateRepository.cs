using System;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class HourlyRateRepository : IHourlyRateRepository, IDisposable
    {
        private readonly ParkingAppContext _context;

        public HourlyRateRepository(ParkingAppContext context)
        {
            _context = context;
        }

        public void CreateNewHourlyRate(HourlyRate hourlyRate)
        {
            _context.HourlyRates.Add(hourlyRate);
            _context.SaveChanges();
        }

        public void DeleteHourlyRate(int id)
        {
            var rateToDelete = GetHourlyRateByID(id);
            _context.HourlyRates.Remove(rateToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<HourlyRate> GetAllHourlyRates()
        {
            return _context.HourlyRates.ToList();
        }

        public HourlyRate GetHourlyRateByID(int id)
        {
            return _context.HourlyRates.FirstOrDefault(d => d.ID == id);
        }

        public void UpdateHourlyRate(HourlyRate hourlyRate)
        {
            _context.HourlyRates.Update(hourlyRate);
            _context.SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
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