using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Schedule.AddSchedule
{
    internal sealed class AddScheduleCommandHandler : IRequestHandler<AddScheduleCommand, BarmenSchedule>
    {
        private readonly IRepository<BarmenSchedule> _barmenScheduleRepository;
        private readonly IRepository<User> _userRepository;

        public AddScheduleCommandHandler(
            IRepository<BarmenSchedule> barmenScheduleRepository,
            IRepository<User> userRepository)
        {
            _barmenScheduleRepository = barmenScheduleRepository;
            _userRepository = userRepository;
        }

        public async Task<BarmenSchedule> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            var barmen = await _userRepository.GetFirstOrDefaultAsync(user => user.Id == request.BarmenId);

            if (barmen is null)
            {
                throw new ExecutingException($"User with id {request.BarmenId} was not found.", System.Net.HttpStatusCode.BadRequest);
            }

            var schedule = BarmenSchedule.Create(request.StartDate, request.EndDate, barmen);
            await _barmenScheduleRepository.AddAsync(schedule);
            await _barmenScheduleRepository.SaveChangesAsync();

            return schedule;
        }
    }
}
