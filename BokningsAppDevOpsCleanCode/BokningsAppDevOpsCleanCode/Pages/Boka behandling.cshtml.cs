using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using BokningsAppDevOpsCleanCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class Boka_behandlingModel : PageModel
    {
        private readonly IBookingService _service;

        public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        [TempData]
        public bool IsTimeBooked { get; set; }
        [TempData]
        public bool BookingSuccess { get; set; }

        [BindProperty]
        public Booking _Booking { get; set; }
        public List<List<int>> CalendarWeeks { get; set; }
        public Boka_behandlingModel(IBookingService service)
        {
            this._service = service;
        }
        public IActionResult OnGet(int year, int month)
        {
            // If the provided year and month are valid, use them; otherwise, use the current date
            if (IsValidYearMonth(year, month))
            {
                CurrentYear = year;
                CurrentMonth = month;
            }
            else
            {
                var currentDate = DateTime.Now;
                CurrentYear = currentDate.Year;
                CurrentMonth = currentDate.Month;
            }

            // Update the calendar
            UpdateCalendar();

            return Page();
        }
        [HttpPost]
        public IActionResult OnPostBookAppointment(string selectedDate, string time, string treatment, string name)
        {
            // Parse the selected date
            DateTime chosenDateTime = DateTime.ParseExact(selectedDate, "d/M/yyyy", CultureInfo.InvariantCulture);

            // Check if a booking with the same ChosenDateTime and ChosenTime already exists
            var existingBooking = GetExistingBooking(chosenDateTime, time);

            if (existingBooking != null)
            {
                // Return an error message
                IsTimeBooked = true;
                return RedirectToPage("/Boka behandling");
            }

            // Create a new Booking object
            var booking = new Booking
            {
                ChosenDateTime = chosenDateTime,
                ChosenTime = time,
                ChosenTreatment = treatment,
                CustomerName = name,
                UserId = User.Identity.Name // Assuming you are using authentication and want to associate the booking with the logged-in user
            };

            // Add the booking to the database and save changes
           

            BookingSuccess = _service.AddBooking(booking);

            // Redirect to a confirmation page or back to the calendar page
            return RedirectToPage("/Boka behandling");
        }

        private Booking GetExistingBooking(DateTime chosenDateTime, string chosenTime)
        {
            // Check if a booking with the same ChosenDateTime and ChosenTime already exists
            return _service.CheckAvailability(chosenDateTime, chosenTime);
                
        }



        public IActionResult OnGetNextMonth()
        {
            // Update the calendar for the next month
            CurrentMonth++;
            if (CurrentMonth > 12)
            {
                CurrentMonth = 1;
                CurrentYear++;
            }

            UpdateCalendar();

            // Redirect to the current page with updated parameters
            return RedirectToPage("Boka_behandling", new { year = CurrentYear, month = CurrentMonth });
        }

        public IActionResult OnGetPreviousMonth()
        {
            // Update the calendar for the previous month
            CurrentMonth--;
            if (CurrentMonth < 1)
            {
                CurrentMonth = 12;
                CurrentYear--;
            }

            UpdateCalendar();

            // Redirect to the current page with updated parameters
            return RedirectToPage("Boka_behandling", new { year = CurrentYear, month = CurrentMonth });
        }

        private void UpdateCalendar()
        {
            // Generate the calendar for the current year and month
            CalendarWeeks = GenerateCalendar(CurrentYear, CurrentMonth);
        }

        private bool IsValidYearMonth(int year, int month)
        {
            // Checks if year and month are valid
            return year >= 1 && month >= 1 && month <= 12;
        }

        private List<List<int>> GenerateCalendar(int year, int month)
        {
            // Method for generating the calander
            List<List<int>> weeks = new List<List<int>>();
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int currentDay = 1;

            while (currentDay <= daysInMonth)
            {
                List<int> week = new List<int>();

                for (int i = 0; i < 7; i++)
                {
                    if (currentDay <= daysInMonth)
                    {
                        week.Add(currentDay);
                        currentDay++;
                    }
                    else
                    {
                        week.Add(0); // Placeholder for empty cells
                    }
                }

                weeks.Add(week);
            }

            return weeks;
        }
    }

}
