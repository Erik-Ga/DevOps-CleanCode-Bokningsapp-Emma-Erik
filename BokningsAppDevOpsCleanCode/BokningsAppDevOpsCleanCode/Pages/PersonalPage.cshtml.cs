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
            // Gets information based on currently logged in identity user
            var user = await _userManager.GetUserAsync(User);

            Bookings = _service.GetBookingsByUserId(user.UserName);

            return Page();
        }

        public async Task<IActionResult> OnPostCancelBookingAsync(int bookingId)
        {
            // Method for canceling bookings
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var booking = _service.GetBookingByIdInt(bookingId);

            if (booking != null && booking.UserId == user.UserName)
            {
                _service.CancelBooking(booking);

                // Redirect to refresh the page after cancellation
                return RedirectToPage("/PersonalPage");
            }

            return RedirectToPage("/PersonalPage");
        }
    }
}
