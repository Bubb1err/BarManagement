using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Schedule.GetScheduleByUser
{
    public class GetScheduleByUserQuery : IRequest<IEnumerable<BarmenSchedule>>
    {
        public GetScheduleByUserQuery(Guid barmenId)
        {

            BarmenId = barmenId;

        }

        public Guid BarmenId { get; }
    }
}
