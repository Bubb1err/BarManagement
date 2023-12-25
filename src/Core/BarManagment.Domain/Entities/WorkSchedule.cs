namespace BarManagment.Domain.Entities
{
    public sealed class WorkSchedule
    {
        public int WorkScheduleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        //foreign 
        public int UserId { get; set; }
    }
}
