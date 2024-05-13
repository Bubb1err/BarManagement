namespace BarManagement.UI.Models.Schedule
{
    public class AddScheduleViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid BarmenId { get; set; }
    }
}
