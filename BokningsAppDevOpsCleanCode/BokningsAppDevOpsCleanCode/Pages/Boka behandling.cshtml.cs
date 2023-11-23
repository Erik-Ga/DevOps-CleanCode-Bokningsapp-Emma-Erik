using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class Boka_behandlingModel : PageModel
    {

        public int CurrentYear { get; private set; }
        public int CurrentMonth { get; private set; }
        public List<List<int>> CalendarWeeks { get; private set; }
        public string MonthInLetters { get; private set; }
        public void OnGet()
        {
            // Set the current year and month
            CurrentYear = DateTime.Now.Year;
            CurrentMonth = DateTime.Now.Month;
            MonthInLetters = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurrentMonth));


            // Generate the calendar weeks
            CalendarWeeks = GenerateCalendarWeeks(CurrentYear, CurrentMonth);
        }

        private List<List<int>> GenerateCalendarWeeks(int year, int month)
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
