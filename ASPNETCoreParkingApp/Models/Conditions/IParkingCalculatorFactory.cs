using ASPNETCoreParkingApp.Models.Calculators;

namespace ASPNETCoreParkingApp.Models.Conditions
{
    public interface IParkingCalculatorFactory
    {
        ParkingChargeCalculator GetParkingCalculator(Parking parking);
    }
}