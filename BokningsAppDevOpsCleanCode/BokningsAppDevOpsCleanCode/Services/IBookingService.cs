using BokningsAppDevOpsCleanCode.Models;

namespace BokningsAppDevOpsCleanCode.Services
{
    public interface IBookingService
    {
        public void CancelBooking(Booking booking);
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(string userId);
        public Booking GetBookingByIdInt(int bookingId);
        public List<Booking> GetBookingsByUserId(string userId);
    }
}