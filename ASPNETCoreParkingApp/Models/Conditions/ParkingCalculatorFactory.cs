using ASPNETCoreParkingApp.Models.Calculators;
using ASPNETCoreParkingApp.Models.Repositories.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreParkingApp.Models.Conditions
{
    public class ParkingCalculatorFactory : IParkingCalculatorFactory
    {
        private readonly ParkingAppContext _context;

        private Dictionary<IParkingCondition, ParkingChargeCalculator> _parkingRules = new Dictionary<IParkingCondition, ParkingChargeCalculator>();

        public ParkingCalculatorFactory(ParkingAppContext context)
        {
            foreach (var rate in context.FlatParkingRates)
            {
                _parkingRules.Add(new FlatRateCondition(rate.EntryTimeStart, rate.EntryTimeEnd, rate.ExitTimeStart, rate.ExitTimeEnd), new FlatRateParkingChargeCalculator(rate.Description, rate.Charge));
            }

            HourlyChargeRates hourlyRates = new HourlyChargeRates();
            foreach (var rate in context.HourlyRates)
            {
                hourlyRates.Add(rate.HourLimit, rate.Charge);
            }
            _parkingRules.Add(
                    new HourlyRateCondition(hourlyRates),
                    new HourlyRateParkingChargeCalculator("Hourly Rate", hourlyRates));

            _parkingRules.Add(
                    new DailyRateCondition(),
                    new DailyRateParkingChargeCalculator("Daily Rate", context.DailyRates.First().Charge));
        }

        public ParkingChargeCalculator GetParkingCalculator(Parking parking)
        {
            return _parkingRules.First(condition => condition.Key.Matches(parking)).Value;
        }
    }
}
