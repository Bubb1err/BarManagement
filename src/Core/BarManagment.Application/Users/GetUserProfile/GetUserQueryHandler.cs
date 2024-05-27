using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Users.GetUserProfile
{
    internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IRepository<User> _userRepository;

        public GetUserQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId, include: i => i.Include(u => u.Schedules));
            return user;
        }
    }
}
