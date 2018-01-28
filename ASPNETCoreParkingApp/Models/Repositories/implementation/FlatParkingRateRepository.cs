using System;
using System.Collections.Generic;
using System.Linq;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;

namespace ASPNETCoreParkingApp.Models.Repositories.implementation
{
    public class FlatParkingRateRepository : IFlatParkingRateRepository, IDisposable
    {
        private readonly ParkingAppContext _context;

        public FlatParkingRateRepository(ParkingAppContext context)
        {
            _context = context;
        }

        public void CreateNewFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            _context.FlatParkingRates.Add(flatParkingRate);
            _context.SaveChanges();
        }

        public void DeleteFlatParkingRate(int id)
        {
            var rateToDelete = GetFlatParkingRateByID(id);
            _context.FlatParkingRates.Remove(rateToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<FlatParkingRate> GetAllFlatParkingRates()
        {
            return _context.FlatParkingRates.ToList();
        }

        public FlatParkingRate GetFlatParkingRateByID(int id)
        {
            return _context.FlatParkingRates.FirstOrDefault(d => d.ID == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateFlatParkingRate(FlatParkingRate flatParkingRate)
        {
            _context.FlatParkingRates.Update(flatParkingRate);
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