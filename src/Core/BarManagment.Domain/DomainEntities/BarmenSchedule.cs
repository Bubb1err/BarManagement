using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class BarmenSchedule : BaseEntity
    {
        public BarmenSchedule(
            Guid id, 
            DateTime startDate, 
            DateTime endDate, 
            User barmen)
            : base(id)
        {
            StartDate = startDate;
            EndDate = endDate;
            UserId = barmen.Id;
        }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        //foreign
        public Guid UserId { get; private set; }
    }
}
