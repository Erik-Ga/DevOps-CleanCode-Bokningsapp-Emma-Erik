using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.UnitTests
{
    public class BookingServiceTests
    {
        //[Fact]
        //public void AddBooking_ShouldAddBookingToDatabase()
        //{
        //    // Arrange
        //    var bookingService = new BookingService();
        //    var bookingToAdd = new Booking { /* initialize properties */ };

        //    // Act
        //    bookingService.AddBooking(bookingToAdd);

        //    // Assert
        //    // You would need to query the database or mock the database to verify the booking was added successfully.
        //    // This could involve checking the count of bookings before and after the addition, or querying the database for the specific booking.
        //    // For simplicity, let's assume an assertion like this:
        //    Assert.True(/* some condition indicating the booking was added */);
        //}

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

        //[Fact]
        //public void CancelBooking_ShouldRemoveBookingFromDatabase()
        //{
        //    // Arrange
        //    var bookingService = new BookingService(_dbContext);
        //    var bookingToCancel = new Booking { /* initialize properties */ };

        //    // Act
        //    bookingService.CancelBooking(bookingToCancel);

        //    // Assert
        //    // Similar to AddBooking, you would need to verify the booking was removed from the database.
        //    Assert.True(/* some condition indicating the booking was canceled */);
        //}
    }
}