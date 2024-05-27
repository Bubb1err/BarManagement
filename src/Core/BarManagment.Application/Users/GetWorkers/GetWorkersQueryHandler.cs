using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Users.GetWorkers
{
    internal class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, IEnumerable<User>>
    {
        private readonly IRepository<User> _userRepository;

        public GetWorkersQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
        {
            var admin = await _userRepository.GetFirstOrDefaultAsync(user => user.Id == request.AdminId);

            if (admin is null)
            {
                throw new ExecutingException("Admin was not found.", System.Net.HttpStatusCode.BadRequest);
            }

            var users = await _userRepository.GetAll(user => user.CompanyCode == admin.CompanyCode && user.Id != admin.Id).ToListAsync();
            return users;
        }
    }
}
