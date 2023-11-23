namespace BokningsAppDevOpsCleanCode.Models
{
    public class Day
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public Booking Bookings { get; set; }

        public Day()
        {
        }
    }
}
