using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Schedule.GetScheduleByUser
{
    internal sealed class GetScheduleByUserQueryHandler : IRequestHandler<GetScheduleByUserQuery, IEnumerable<BarmenSchedule>>
    {
        private readonly IRepository<BarmenSchedule> _scheduleRepository;

        public GetScheduleByUserQueryHandler(IRepository<BarmenSchedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<BarmenSchedule>> Handle(GetScheduleByUserQuery request, CancellationToken cancellationToken)
        {
            return await _scheduleRepository.GetAll(schedule => schedule.UserId == request.BarmenId).ToListAsync();
        }
    }
}
