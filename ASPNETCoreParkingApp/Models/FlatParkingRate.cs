using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ASPNETCoreParkingApp.Models
{
    public class FlatParkingRate
    {
        private const int SUNDAY = 1;
        private const int MONDAY = 2;
        private const int TUESDAY = 4;
        private const int WEDNESDAY = 8;
        private const int THURSDAY = 16;
        private const int FRIDAY = 32;
        private const int SATURDAY = 64;

        private readonly Dictionary<int, string> DaysOfWeekMap = new Dictionary<int, string>
        {
            { SUNDAY, "Sun" },
            { MONDAY, "Mon" },
            { TUESDAY, "Tue" },
            { WEDNESDAY, "Wed" },
            { THURSDAY, "Thu" },
            { FRIDAY, "Fri" },
            { SATURDAY, "Sat" },
        };

        public int ID { get; set; }

        public string Description { get; set; }

        [NotMapped]
        [Display(Name = "Entry From")]
        public TimeSpan EntryTimeStart { get; set; }
        [NotMapped]
        [Display(Name = "Entry To")]
        public TimeSpan EntryTimeEnd { get; set; }
        [NotMapped]
        [Display(Name = "Exit From")]
        public TimeSpan ExitTimeStart { get; set; }
        [NotMapped]
        [Display(Name = "Exit To")]
        public TimeSpan ExitTimeEnd { get; set; }

        public long EntryTimeStartTicks
        {
            get => EntryTimeStart.Ticks;
            set => EntryTimeStart = TimeSpan.FromTicks(value);
        }
        public long EntryTimeEndTicks
        {
            get => EntryTimeEnd.Ticks;
            set => EntryTimeEnd = TimeSpan.FromTicks(value);
        }
        public long ExitTimeStartTicks
        {
            get => ExitTimeStart.Ticks;
            set => ExitTimeStart = TimeSpan.FromTicks(value);
        }
        public long ExitTimeEndTicks
        {
            get => ExitTimeEnd.Ticks;
            set => ExitTimeEnd = TimeSpan.FromTicks(value);
        }

        // 1 = Sunday, 2 = Monday, 4 = Tuesday, 8 = Wednesday, 16 = Thursday, 32 = Friday, 64 = Saturday
        public int EntryDays { get; set; }

        [Display(Name = "Cost ($)")]
        public decimal Charge { get; set; }

/*        {
                    get => (EntrySunday ? SUNDAY : 0)
                         & (EntryMonday ? MONDAY : 0)
                         & (EntryTuesday ? MONDAY : 0)
                         & (EntryWednesday ? MONDAY : 0)
                         & (EntryThursday ? MONDAY : 0)
                         & (EntryFriday ? MONDAY : 0)
                         & (EntrySaturday ? MONDAY : 0);
                    set
                    {
                        EntrySunday = (value & SUNDAY) == SUNDAY;
                        EntryMonday = (value & MONDAY) == MONDAY;
                        EntryTuesday = (value & TUESDAY) == TUESDAY;
                        EntryWednesday = (value & WEDNESDAY) == WEDNESDAY;
                        EntryThursday = (value & THURSDAY) == THURSDAY;
                        EntryFriday = (value & FRIDAY) == FRIDAY;
                        EntrySaturday = (value & SATURDAY) == SATURDAY;

                    }
                }
                */
        public int ExitDays { get; set; }

        /*
        [NotMapped]
        [Display(Name = "Sun")]
        public bool EntrySunday { get; set; }
        [NotMapped]
        [Display(Name = "Mon")]
        public bool EntryMonday { get; set; }
        [NotMapped]
        [Display(Name = "Tue")]
        public bool EntryTuesday { get; set; }
        [NotMapped]
        [Display(Name = "Wed")]
        public bool EntryWednesday { get; set; }
        [NotMapped]
        [Display(Name = "Thu")]
        public bool EntryThursday { get; set; }
        [NotMapped]
        [Display(Name = "Fri")]
        public bool EntryFriday { get; set; }
        [NotMapped]
        [Display(Name = "Sat")]
        public bool EntrySaturday { get; set; }
        */

        [NotMapped]
        [Display(Name = "Entry Days")]
        public string EntryDaysOfWeek
        {
            get
            {
                var entryDays = EntryDays;
                var dayNames = DaysOfWeekMap
                                .Where(kvp => (kvp.Key & entryDays) == kvp.Key)
                                .Select(kvp => kvp.Value);
                if (dayNames.Count() == 0)
                    return "";
                
                return dayNames.Aggregate((current, next) => current + ", " + next);
            }
        }
    }
}