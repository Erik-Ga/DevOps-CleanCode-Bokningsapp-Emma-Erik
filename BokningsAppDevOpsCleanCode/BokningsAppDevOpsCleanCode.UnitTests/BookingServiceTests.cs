using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.UnitTests
{
    public class BookingServiceTests
    {
        [Fact]
        public void AddBooking_ShouldAddBookingToDatabase()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var bookingToAdd = new Booking()
            {
                Id = 100,
                UserId = "AddingCustomer1@hotmail.com",
                ChosenDateTime = DateTime.Parse("2023 - 12 - 24 00:00:00.0000000"),
                ChosenTime = "16:00-17:00",
                ChosenTreatment = "Treatment1"
            };

            // Act
            var isBooked = bookingService.AddBooking(bookingToAdd);

            // Assert
            Assert.True(isBooked);
        }
        [Fact]
        public void CancelBooking_ShouldRemoveBookingFromDatabase()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var bookingToCancel = new Booking()
            {
                Id = 100,
                UserId = "AddingCustomer1@hotmail.com",
                ChosenDateTime = DateTime.Parse("2023 - 12 - 24 00:00:00.0000000"),
                ChosenTime = "16:00-17:00",
                ChosenTreatment = "Treatment1"
            };

            // Act
            var isCanceled = bookingService.CancelBooking(bookingToCancel);

            // Assert
            Assert.True(isCanceled);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void CancelBookingById_ShouldReturnTrue(int id)
        {
            //Arrange
            var bookingService = new MockDatabase();

            //Act
            var actual = bookingService.CancelBookingById(id);

            //Assert
            Assert.True(actual);
        }
        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        public void CancelBookingById_ShouldReturnFalse(int id) 
        {
            //Arrange
            var bookingService = new MockDatabase();

            //Act
            var actual = bookingService.CancelBookingById(id);

            //Assert
            Assert.False(actual);
        }
        [Fact]
        public void GetBookingsFromUserWithUserId_ShouldReturnUserHasBooking()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var userId = "sealis2@hotmail.com"; // Replace with a valid user ID

            // Act
            var bookings = bookingService.GetBookingFromPersonWithUserId(userId);


            // Assert
            Assert.NotNull(bookings);
            // You might have more specific assertions based on the expected behavior of the method.
        }
        [Fact]
        public void GetTreatmentFromUser_ShouldNotReturnThatUserHasBookedTreatment2()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var userId = "sealis@hotmail.com"; // Replace with a valid user ID

            // Act
            var booking = bookingService.GetBookingFromPersonWithUserId(userId);
            var expected = "treatment2";
            var actual = booking.ChosenTreatment;

            // Assert
            Assert.Equal(expected,actual);
            // You might have more specific assertions based on the expected behavior of the method.
        }
        [Theory]
        [InlineData("emma@hotmail.com")]
        [InlineData("erik@hotmail.com")]
        [InlineData("tezla@hotmail.com")]
        [InlineData("sealis@hotmail.com")]
        [InlineData("cheato@hotmail.com")]
        [InlineData("drakis@hotmail.com")]
        public void CheckIfCustomersByUserIdHasBookings_ShouldReturnTrue(string userId)
        {
            //Arrange
            var bookingService = new MockDatabase();
            var expected = true;
            //Act
            var actual = bookingService.GetAndCheckIfCustomersHasBookings(userId);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("09:00-10:00")]
        [InlineData("11:00-12:00")]
        [InlineData("13:00-14:00")]
        [InlineData("14:00-15:00")]
        [InlineData("15:00-16:00")]
        [InlineData("16:00-17:00")]
        public void CheckIfTimeOnTheSameDateIsTaken_ShouldReturnTrue(string bookingTime)
        {
            //Arrange
            var bookingService = new MockDatabase();
            var expected = true;

            //Act
            var actual = bookingService.CheckIfTimeOnTheSameDateIsTaken(bookingTime);

            //Assert

            Assert.Equal(expected, actual);
        }

    }
}