using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Models.Buyings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Buyings.Queries.GetSpendings
{
    internal sealed class GetSpendingsQueryHandler : IRequestHandler<GetSpendingsQuery, IEnumerable<SpendingViewModel>>
    {
        private readonly IBuyingsRepository _buyingsRepository;
        private readonly IRepository<User> _usersRepository;

        public GetSpendingsQueryHandler(IBuyingsRepository buyingsRepository,
            IRepository<User> usersRepository)
        {
            _buyingsRepository = buyingsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<SpendingViewModel>> Handle(GetSpendingsQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);

            var spendings = await _buyingsRepository.GetSpendings(user.CompanyCode).ToListAsync();
            return spendings;
        }
    }
}
