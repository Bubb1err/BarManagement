using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Buyings.Queries.GetBuyings
{
    internal sealed class GetBuyingsQueryHandler : IRequestHandler<GetBuyingsQuery, IEnumerable<Buying>>
    {
        private readonly IBuyingsRepository _buyingsRepository;
        private readonly IRepository<User> _usersRepository;

        public GetBuyingsQueryHandler(IBuyingsRepository buyingsRepository,
            IRepository<User> usersRepository)
        {
            _buyingsRepository = buyingsRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<Buying>> Handle(GetBuyingsQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);

            var buyings = await _buyingsRepository.GetAll(b => b.CompanyCode == user.CompanyCode
                ,include: i => 
                i.Include(buying => buying.Commodity).ThenInclude(commodity => commodity.DefaultMeasure)).ToListAsync(cancellationToken);

            return buyings.OrderBy(b => b.PurchaseDate);
        }
    }
}
