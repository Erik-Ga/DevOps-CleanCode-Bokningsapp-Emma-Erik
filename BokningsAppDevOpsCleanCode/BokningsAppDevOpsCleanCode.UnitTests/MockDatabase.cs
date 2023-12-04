using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppDevOpsCleanCode.UnitTests
{
    public class MockDatabase : IBookingService
    {
        public void CancelBooking(Booking booking)
        {

        }
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            var booking = new Booking
            {
                Id = 3,
                UserId = "sealis2@hotmail.com",
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            return bookings;
        }
        //Kolla om nödvändigt att ha kvar?
        public Booking GetBookingById(string userId)
        {
            var booking = new Booking
            {
                Id = 3,
                UserId = userId,
                ChosenTreatment = "treatment2",
                ChosenDateTime =  DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            return booking;
        }
        //Kolla om nödvändigt att ha kvar?
        public Booking GetBookingByIdInt(int bookingId)
        {
            var booking = new Booking
            {
                Id = bookingId,
                UserId = "sealis2@hotmail.com",
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            return booking;
        }
        //Används ej i något test än
        public Booking GetBookingFromPersonWithUserId(string userId)
        {
            var booking = new Booking
            {
                Id = 3,
                UserId = userId,
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            return booking;
        }
        public Booking GetBookingFromPersonWithId3(int bookingId)
        {
            var booking = new Booking
            {
                Id = bookingId,
                UserId = "sealis2@hotmail.com",
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            return booking;
        }
        public List<Booking> GetBookingsByUserId(string userId)
        {
            List<Booking> bookings = new List<Booking>();

            var booking = new Booking
            {
                Id = 3,
                UserId = userId,
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "10:00-11:00"
            };

            bookings.Add(booking);

            return bookings;
        }

    }
}
