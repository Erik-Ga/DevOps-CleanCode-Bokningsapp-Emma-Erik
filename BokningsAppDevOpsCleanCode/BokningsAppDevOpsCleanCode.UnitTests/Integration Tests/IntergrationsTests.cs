using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppDevOpsCleanCode.UnitTests.Integration_Tests
{
    public class IntergrationsTests
    {
        [Fact]
        public void AddBooking_ToActualDatabase_ShouldRetrieveFromDatabase()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddDbContext<FootBookDbContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<FootBookDbContext>();
            dbContext.Database.EnsureCreated();

            var bookingService = new BookingService(dbContext);
            var bookingToAdd = new Booking()
            {
                CustomerName = "Sealis",
                UserId = "sealis@hotmail.com",
                ChosenTreatment = "treatment4",
                ChosenDateTime = DateTime.Parse("2023 - 12 - 24 00:00:00.0000000"),
                ChosenTime = "14:00-15:00"
            };

            // Act
            bookingService.AddBooking(bookingToAdd);

            // Assert
            var retrievedBooking = dbContext.Bookings.FirstOrDefault(b => b.UserId == bookingToAdd.UserId);
            Assert.NotNull(retrievedBooking);
            Assert.Equal(bookingToAdd.UserId, retrievedBooking.UserId);
            Assert.Equal(bookingToAdd.ChosenDateTime, retrievedBooking.ChosenDateTime);
            Assert.Equal(bookingToAdd.ChosenTime, retrievedBooking.ChosenTime);
            Assert.Equal(bookingToAdd.ChosenTreatment, retrievedBooking.ChosenTreatment);
        }
    }
}
