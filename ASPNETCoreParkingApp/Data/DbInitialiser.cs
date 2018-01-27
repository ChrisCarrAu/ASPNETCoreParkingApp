using ASPNETCoreParkingApp.Models;
using System;
using System.Linq;

namespace ASPNETCoreParkingApp.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(ParkingAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.FlatParkingRates.Any())
            {
                return;
            }

            var flatParkingRates = new FlatParkingRate[]
            {
                new FlatParkingRate
                {
                    Description = "Early Bird",
                    EntryTimeStart = TimeSpan.Parse("06:00"),
                    EntryTimeEnd = TimeSpan.Parse("09:00"),
                    ExitTimeStart = TimeSpan.Parse("15:30"),
                    ExitTimeEnd = TimeSpan.Parse("23:30"),
                    EntryDays = 62,
                    Charge = 13.00m
                },
                new FlatParkingRate
                {
                    Description = "Night Rate",
                    EntryTimeStart = TimeSpan.Parse("18:00"),
                    EntryTimeEnd = TimeSpan.Parse("1.00:00"),
                    ExitTimeStart = TimeSpan.Parse("18:00"),
                    ExitTimeEnd = TimeSpan.Parse("1.06:00"),
                    EntryDays = 62,
                    Charge = 6.50m
                },
                new FlatParkingRate
                {
                    Description = "Weekend Rate",
                    EntryTimeStart = TimeSpan.Parse("00:00"),
                    EntryTimeEnd = TimeSpan.Parse("2.00:00"),
                    ExitTimeStart = TimeSpan.Parse("00:00"),
                    ExitTimeEnd = TimeSpan.Parse("2.00:00"),
                    EntryDays = 64,
                    Charge = 10.00m
                },
                new FlatParkingRate
                {
                    Description = "Weekend Rate",
                    EntryTimeStart = TimeSpan.Parse("00:00"),
                    EntryTimeEnd = TimeSpan.Parse("1.00:00"),
                    ExitTimeStart = TimeSpan.Parse("00:00"),
                    ExitTimeEnd = TimeSpan.Parse("1.00:00"),
                    EntryDays = 1,
                    Charge = 10.00m
                },
            };
            foreach (var rate in flatParkingRates)
            {
                context.FlatParkingRates.Add(rate);
            }
            context.SaveChanges();

            var hourlyRates = new HourlyRate[]
            {
                new HourlyRate {HourLimit = 1, Charge = 5.00m},
                new HourlyRate {HourLimit = 2, Charge = 10.00m},
                new HourlyRate {HourLimit = 3, Charge = 15.00m},
            };
            foreach (var rate in hourlyRates)
            {
                context.HourlyRates.Add(rate);
            }

            var dailyRate = new DailyRate {Charge = 20.00m};
            context.DailyRates.Add(dailyRate);
            context.SaveChanges();
        }
    }
}
