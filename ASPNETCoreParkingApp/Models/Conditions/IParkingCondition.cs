﻿namespace ASPNETCoreParkingApp.Models.Conditions
{
    /// <summary>
    /// Identifies if the parking instance matches this parking condition
    /// </summary>
    public interface IParkingCondition
    {
        bool Matches(Parking parking);
    }
}