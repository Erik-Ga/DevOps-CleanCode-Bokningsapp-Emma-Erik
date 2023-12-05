using System;
using System.Collections.Generic;
using System.Linq;
using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.Services
{
    public class BookingService : IBookingService
    {
        private readonly FootBookDbContext _context;

        public BookingService(FootBookDbContext context)
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
        public Booking GetBookingByIdInt(int bookingId)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
        }

        public bool CancelBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            var changes = _context.SaveChanges();

            return changes > 0;
        }
        public List<Booking> GetAllBookings()
        {
            // Retrieve all bookings and order by ChosenDateTime
            return _context.Bookings.OrderBy(b => b.ChosenDateTime).ToList();
        }

        public bool AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            var changes = _context.SaveChanges();

            return changes > 0;
        }

        public Booking CheckAvailability(DateTime chosenDateTime, string chosenTime)
        {
            var availability = _context.Bookings
                .FirstOrDefault(b =>
                    b.ChosenDateTime == chosenDateTime &&
                    b.ChosenTime == chosenTime
                );

            return availability;
        }
    }
}

