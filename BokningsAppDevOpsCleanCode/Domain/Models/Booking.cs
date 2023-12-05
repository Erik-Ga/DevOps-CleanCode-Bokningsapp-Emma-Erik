using Domain.Interfaces;

namespace BokningsAppDevOpsCleanCode.Models
{
    internal class Booking : IBooking
    {
        public int Id { get; set; }
        public DateTime ChosenDateTime { get; set; }
        public string ChosenTime { get; set; }
        public string ChosenTreatment { get; set; }
        public string CustomerName { get; set; }
        public string UserId { get; set; }
    }
}
