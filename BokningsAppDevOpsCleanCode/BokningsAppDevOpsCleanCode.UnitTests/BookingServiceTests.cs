using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.UnitTests
{
    public class BookingServiceTests
    {
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
            Assert.Equal(expected, actual);
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
            //Act
            var expected = true;
            var actual = bookingService.GetAndCheckIfCustomersHasBookings(userId);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}