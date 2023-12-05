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
        private readonly IBookingService _service;

        public PersonalPageModel(UserManager<IdentityUser> userManager, IBookingService service)
        {
            _userManager = userManager;
            this._service = service;
        }
        public List<Booking> Bookings { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            Bookings = _service.GetBookingsByUserId(user.UserName);

            return Page();
        }

        public async Task<IActionResult> OnPostCancelBookingAsync(string bookingId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var booking = _service.GetBookingById(bookingId);

            if (booking != null && booking.UserId == user.UserName)
            {
                // Implement the logic to cancel/delete the booking from the database
                _service.CancelBooking(booking);

                // Redirect to refresh the page after cancellation
                return RedirectToPage("/PersonalPage");
            }

            return RedirectToPage("/PersonalPage");
        }
    }
}
