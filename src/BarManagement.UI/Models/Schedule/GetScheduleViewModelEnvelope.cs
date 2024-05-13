namespace BarManagement.UI.Models.Schedule
{
    public class GetScheduleViewModelEnvelope
    {
        public Guid BarmenId { get; set; }

        public IEnumerable<GetScheduleViewModel> Schedules {get;set;}
    }
}
