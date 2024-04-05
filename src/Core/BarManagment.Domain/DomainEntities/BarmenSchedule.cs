using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class BarmenSchedule : BaseEntity
    {
        private BarmenSchedule(
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

        private BarmenSchedule() { }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public Guid UserId { get; private set; }

        public static BarmenSchedule Create(DateTime startDate, DateTime endDate, User barmen)
        {
            return new BarmenSchedule(Guid.NewGuid(), startDate, endDate, barmen);
        }
    }
}
