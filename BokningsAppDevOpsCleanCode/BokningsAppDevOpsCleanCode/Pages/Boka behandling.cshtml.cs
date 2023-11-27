using BokningsAppDevOpsCleanCode.Data;
using BokningsAppDevOpsCleanCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class Boka_behandlingModel : PageModel
    {
        public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        public List<List<int>> CalendarWeeks { get; set; }

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
            return year >= 1 && month >= 1 && month <= 12;
        }

        private List<List<int>> GenerateCalendar(int year, int month)
        {
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
