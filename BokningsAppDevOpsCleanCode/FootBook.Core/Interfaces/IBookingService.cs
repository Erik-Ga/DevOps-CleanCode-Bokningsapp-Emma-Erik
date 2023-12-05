using BokningsAppDevOpsCleanCode.Models;

namespace BokningsAppDevOpsCleanCode.Services
{
    public interface IBookingService
    {
        public bool CancelBooking(Booking booking);
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(string userId);
        public List<Booking> GetBookingsByUserId(string userId);
        public Booking GetBookingByIdInt(int bookingId);
        public bool AddBooking(Booking booking);
        public Booking CheckAvailability(DateTime chosenDateTime, string chosenTime);
    }
}