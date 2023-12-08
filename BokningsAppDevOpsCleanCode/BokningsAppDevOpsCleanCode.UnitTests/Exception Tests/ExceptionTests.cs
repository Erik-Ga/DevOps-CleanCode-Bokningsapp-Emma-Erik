using BokningsAppDevOpsCleanCode.Models;

namespace BokningsAppDevOpsCleanCode.UnitTests.Exception_Tests
{
    public class ExceptionTests
    {
        [Fact]
        public void AddBookingWithInvalidData_ShouldThrowException()
        {
            //Arrange
            var bookingService = new MockDatabase();
            var invalidBooking = new Booking()
            {

            };
            invalidBooking = null;
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => bookingService.AddBooking(invalidBooking));

        }
        [Fact]
        public void AddBookingWithInvalidDate_ShouldThrowException()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var bookingWithInvalidDate = new Booking()
            {
                UserId = "testUser",
                ChosenDateTime = DateTime.MinValue,
                ChosenTime = "14:00-15:00",
                ChosenTreatment = "Treatment1"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bookingService.AddBooking(bookingWithInvalidDate));
        }
        [Fact]
        public void AddBookingWithMissingUserId_ShouldThrowException()
        {
            // Arrange
            var bookingService = new MockDatabase();
            var bookingWithMissingUserId = new Booking()
            {
                ChosenDateTime = DateTime.Now,
                ChosenTime = "14:00-15:00",
                ChosenTreatment = "Treatment1"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bookingService.AddBooking(bookingWithMissingUserId));
        }

    }
}
