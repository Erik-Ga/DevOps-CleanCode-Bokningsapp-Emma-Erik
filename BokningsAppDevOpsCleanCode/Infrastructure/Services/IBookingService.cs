using BokningsAppDevOpsCleanCode.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace BokningsAppDevOpsCleanCode.Services
{
    public interface IBookingService
    {
        public void CancelBooking(IBooking booking);
        public List<IBooking> GetAllBookings();
        public IBooking GetBookingById(string userId);
        public List<IBooking> GetBookingsByUserId(string userId);
        public IBooking GetBookingByIdInt(int bookingId);

    }
}