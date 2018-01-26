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
    }
}