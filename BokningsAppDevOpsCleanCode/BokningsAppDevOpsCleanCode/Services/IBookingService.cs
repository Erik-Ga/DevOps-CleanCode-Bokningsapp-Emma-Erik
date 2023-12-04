using BokningsAppDevOpsCleanCode.Models;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.Services
{
    public interface IBookingService
    {
        public void CancelBooking(Booking booking);
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(string userId);
        public List<Booking> GetBookingsByUserId(string userId);
        public Booking GetBookingByIdInt(int bookingId);

    }
}