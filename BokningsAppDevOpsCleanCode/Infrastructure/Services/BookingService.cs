﻿using System;
using System.Collections.Generic;
using System.Linq;
using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace BokningsAppDevOpsCleanCode.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IBooking> GetBookingsByUserId(string userId)
        {
            return _context.Bookings
                .Where(b => b.UserId == userId)
                .OrderBy(b => b.ChosenDateTime)
                .ToList();
        }

        public IBooking GetBookingById(string userId)
        {
            return _context.Bookings.FirstOrDefault(b => b.UserId == userId);
        }
        public IBooking GetBookingByIdInt(int bookingId)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
        }

        public void CancelBooking(IBooking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
        public List<IBooking> GetAllBookings()
        {
            // Retrieve all bookings and order by ChosenDateTime
            return _context.Bookings.OrderBy(b => b.ChosenDateTime).ToList();
        }
    }
}

