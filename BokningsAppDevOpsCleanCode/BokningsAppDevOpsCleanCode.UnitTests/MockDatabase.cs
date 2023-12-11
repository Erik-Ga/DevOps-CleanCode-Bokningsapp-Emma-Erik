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
        // All the methods used for the MockDatabase unittesting
        public bool AddBooking(Booking booking)
        {
            // Check for null booking
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking), "Bokningen kan inte vara null");
            }

            // Validate specific properties of the booking
            if (string.IsNullOrWhiteSpace(booking.UserId))
            {
                throw new ArgumentException("UserId saknas", nameof(booking.UserId));
            }

            if (booking.ChosenDateTime == DateTime.MinValue)
            {
                throw new ArgumentException("ChosenDateTime saknas eller är felaktig", nameof(booking.ChosenDateTime));
            }

            if (string.IsNullOrWhiteSpace(booking.ChosenTime))
            {
                throw new ArgumentException("ChosenTime saknas eller ör felaktig", nameof(booking.ChosenTime));
            }

            if (string.IsNullOrWhiteSpace(booking.ChosenTreatment))
            {
                throw new ArgumentException("ChosenTreatment saknas", nameof(booking.ChosenTreatment));
            }

            return true;
        }
        public bool CancelBooking(Booking booking)
        {
            return true;
        }
        public bool CancelBookingById(int bookingId)
        {
            var bookingCanBeDeleted = false;
            List<int> ids = new List<int>();

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

            ids.Add(booking1.Id);
            ids.Add(booking2.Id);
            ids.Add(booking3.Id);
            ids.Add(booking4.Id);
            ids.Add(booking5.Id);
            ids.Add(booking6.Id);

            foreach(var id in ids)
            {
                if(id == bookingId)
                {
                    bookingCanBeDeleted = true;
                    break;
                }
            }
            return bookingCanBeDeleted;
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
        public bool CheckIfTimeOnTheSameDateIsTaken(string booking)
        {
            var isBooked = false;
            List<string> bookedBookings = new List<string>();

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

            bookedBookings.Add(booking1.ChosenTime);
            bookedBookings.Add(booking2.ChosenTime);
            bookedBookings.Add(booking3.ChosenTime);
            bookedBookings.Add(booking4.ChosenTime);
            bookedBookings.Add(booking5.ChosenTime);
            bookedBookings.Add(booking6.ChosenTime);

            foreach(var bookingInList in bookedBookings)
            {
                if(booking == bookingInList)
                {
                    isBooked = true;
                    break;
                }
            }
            return isBooked;
        }
    }
}
