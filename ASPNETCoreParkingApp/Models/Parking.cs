using System;

namespace ASPNETCoreParkingApp.Models
{
    public class Parking
    {
        // Inputs
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }

        // Calculated values
        public bool Calculated { get; set; }
        public string ParkingCondition { get; set; }
        public decimal Charge { get; set; }

        /// <summary>
        /// The duration of this parking
        /// </summary>
        private TimeSpan Duration => Exit.Subtract(Entry);

        /// <summary>
        /// The number of days (whole or partial) parking
        /// </summary>
        public int Days => (int)(Duration.TotalDays) + 1;

        /// <summary>
        /// The number of hours (whole or partial) of parking
        /// </summary>
        public int Hours => (int)(Duration.TotalHours) + 1;
    }
}