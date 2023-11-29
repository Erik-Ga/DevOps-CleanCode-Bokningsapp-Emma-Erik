using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class PersonalPageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BookingService _bookingService;

        public PersonalPageModel(UserManager<IdentityUser> userManager, BookingService bookingService)
        {
            _userManager = userManager;
            _bookingService = bookingService;
        }
        public List<Booking> Bookings { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            Bookings = _bookingService.GetBookingsByUserId(user.UserName);

            return Page();
        }

        public async Task<IActionResult> OnPostCancelBookingAsync(string bookingId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var booking = _bookingService.GetBookingById(bookingId);

            if (booking != null && booking.UserId == user.UserName)
            {
                // Implement the logic to cancel/delete the booking from the database
                _bookingService.CancelBooking(booking);

                // Redirect to refresh the page after cancellation
                return RedirectToPage("/PersonalPage");
            }

            return RedirectToPage("/PersonalPage");
        }
    }
}
