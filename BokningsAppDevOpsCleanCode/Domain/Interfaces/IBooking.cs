namespace Domain.Interfaces
{
    public interface IBooking
    {
        DateTime ChosenDateTime { get; set; }
        string ChosenTime { get; set; }
        string ChosenTreatment { get; set; }
        string CustomerName { get; set; }
        int Id { get; set; }
        string UserId { get; set; }
    }
}