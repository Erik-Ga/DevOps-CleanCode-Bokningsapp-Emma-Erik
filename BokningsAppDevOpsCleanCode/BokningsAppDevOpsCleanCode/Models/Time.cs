namespace BokningsAppDevOpsCleanCode.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string SpecificTime { get; set; }
        public bool IsBooked { get; set; }

        public Time()
        {
            
        }
    }
}
