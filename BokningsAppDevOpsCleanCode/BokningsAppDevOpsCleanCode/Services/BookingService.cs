using System;
using System.Collections.Generic;
using System.Linq;
using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Booking> GetBookingsByUserId(string userId)
        {
            return _context.Bookings
                .Where(b => b.UserId == userId)
                .OrderBy(b => b.ChosenDateTime)
                .ToList();
        }

        public Booking GetBookingById(string userId)
        {
            return _context.Bookings.FirstOrDefault(b => b.UserId == userId);
        }

        public void CancelBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

    }
}

