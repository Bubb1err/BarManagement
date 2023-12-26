using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class WorkSchedule : Entity
    {
        public WorkSchedule(
            Guid id, 
            DateTime startDateTime, 
            DateTime endDateTime, 
            User user)
            : base (id)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            UserId = user.Id;
        }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        //foreign 
        public Guid UserId { get; private set; }
    }
}
