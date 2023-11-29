using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BokningsAppDevOpsCleanCode.Services;
using BokningsAppDevOpsCleanCode.Models;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly BookingService _bookingService;

        public AdminPageModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public List<Booking> AllBookings { get; set; }

        public void OnGet()
        {
            // Retrieve all bookings from the service
            AllBookings = _bookingService.GetAllBookings();
        }

        // This handler is triggered when a booking is canceled
        public IActionResult OnPostCancelBooking(int bookingId)
        {
            // Get the booking from the service
            var booking = _bookingService.GetBookingByIdInt(bookingId);

            if (booking != null)
            {
                // Implement the logic to cancel/delete the booking from the database
                _bookingService.CancelBooking(booking);

                // Redirect to refresh the page after cancellation
                return RedirectToPage("/AdminPage");
            }

            // Redirect to the current page if the booking is not found
            return RedirectToPage("/AdminPage");
        }
    }
}

