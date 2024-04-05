using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Schedule.AddSchedule
{
    public sealed class AddScheduleCommand : IRequest<BarmenSchedule>
    {
        public AddScheduleCommand(
            DateTime startDate,
            DateTime endDate,
            Guid barmenId)
        {
            StartDate = startDate;
            EndDate = endDate;
            BarmenId = barmenId;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid BarmenId { get; set; }
    }
}
