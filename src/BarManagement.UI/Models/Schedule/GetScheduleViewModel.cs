namespace BarManagement.UI.Models.Schedule
{
    public class GetScheduleViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid UserId { get; set; }
    }
}
