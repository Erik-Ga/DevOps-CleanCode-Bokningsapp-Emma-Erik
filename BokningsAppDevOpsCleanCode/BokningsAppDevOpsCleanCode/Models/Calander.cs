namespace BokningsAppDevOpsCleanCode.Models
{
    public class Calander
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public List<Week> Weeks { get; set;}

        public Calander() 
        { 
            Month = DateTime.Now.Month.ToString();
        }
    }
}
