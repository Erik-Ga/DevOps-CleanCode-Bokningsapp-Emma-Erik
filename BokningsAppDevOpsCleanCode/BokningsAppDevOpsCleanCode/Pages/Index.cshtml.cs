using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BokningsAppDevOpsCleanCode.Models;

namespace BokningsAppDevOpsCleanCode.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }
        public Calander Calander { get; set; }
        public Week Week { get; set; }
        public Day Day { get; set; }
        public Time Time { get; set; }
        public void OnGet()
        {
        }
    }
}