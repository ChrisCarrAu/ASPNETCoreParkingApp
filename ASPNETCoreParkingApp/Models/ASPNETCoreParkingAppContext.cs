using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreParkingApp.Models
{
    public class ASPNETCoreParkingAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ASPNETCoreParkingAppContext(DbContextOptions<ASPNETCoreParkingAppContext> options) : base(options)
        {
        }

        public DbSet<FlatParkingRate> FlatParkingRates { get; set; }

        public DbSet<HourlyRate> HourlyRates { get; set; }

        public DbSet<DailyRate> DailyRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlatParkingRate>().ToTable("FlatParkingRate");
            modelBuilder.Entity<HourlyRate>().ToTable("HourlyRate");
            modelBuilder.Entity<DailyRate>().ToTable("DailyRate");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("DefaultConnection");
        }
    }
}
