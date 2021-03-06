﻿namespace ASPNETCoreParkingApp.Models.Calculators
{
    /// <summary>
    /// Given a parking usage instance, returns the charge.
    /// </summary>
    public interface IParkingCalculator
    {
        decimal Charge(Parking parking);
    }
}
