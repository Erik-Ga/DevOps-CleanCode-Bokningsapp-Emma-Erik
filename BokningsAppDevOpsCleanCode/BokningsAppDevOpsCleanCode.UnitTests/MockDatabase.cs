using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppDevOpsCleanCode.UnitTests
{
    public class MockDatabase : IBookingService
    {
        public bool CancelBooking(Booking booking)
        {
            return true;
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
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
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
        public bool AddBooking(Booking booking)
        {
            return true;
        }
        public Booking CheckAvailability(DateTime chosenDateTime, string chosenTime)
        {
            return new Booking();
        }
        public bool GetAndCheckIfCustomersHasBookings(string userId)
        {
            List<string> userIds = new List<string>();

            var booking1 = new Booking
            {
                Id = 1,
                UserId = "emma@hotmail.com",
                ChosenTreatment = "treatment1",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "09:00-10:00"
            };
            var booking2 = new Booking
            {
                Id = 2,
                UserId = "erik@hotmail.com",
                ChosenTreatment = "treatment2",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "11:00-12:00"
            };
            var booking3 = new Booking
            {
                Id = 3,
                UserId = "tezla@hotmail.com",
                ChosenTreatment = "treatment3",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "13:00-14:00"
            };
            var booking4 = new Booking
            {
                Id = 4,
                UserId = "sealis@hotmail.com",
                ChosenTreatment = "treatment4",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "14:00-15:00"
            };
            var booking5 = new Booking
            {
                Id = 5,
                UserId = "cheato@hotmail.com",
                ChosenTreatment = "treatment5",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "15:00-16:00"
            };
            var booking6 = new Booking
            {
                Id = 6,
                UserId = "drakis@hotmail.com",
                ChosenTreatment = "treatment1",
                ChosenDateTime = DateTime.Parse("2023 - 11 - 29 00:00:00.0000000"),
                ChosenTime = "16:00-17:00"
            };

            userIds.Add(booking1.UserId);
            userIds.Add(booking2.UserId);
            userIds.Add(booking3.UserId);
            userIds.Add(booking4.UserId);
            userIds.Add(booking5.UserId);
            userIds.Add(booking6.UserId);

            if (userIds.Contains(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
