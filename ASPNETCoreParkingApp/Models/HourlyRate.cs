namespace ASPNETCoreParkingApp.Models
{
    public class HourlyRate
    {
        public int ID { get; set; }
        public int HourLimit { get; set; }
        public decimal Charge { get; set; }
    }
}