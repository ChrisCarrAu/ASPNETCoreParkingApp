namespace ASPNETCoreParkingApp.Models.Conditions
{
    public class DailyRateCondition : ParkingCondition, IParkingCondition
    {
        public override bool Matches(Parking parking)
        {
            return true;
        }
    }
}
