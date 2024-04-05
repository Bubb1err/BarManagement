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

        public GetBuyingsQueryHandler(IBuyingsRepository buyingsRepository)
        {
            _buyingsRepository = buyingsRepository;
        }
        public async Task<IEnumerable<Buying>> Handle(GetBuyingsQuery request, CancellationToken cancellationToken)
        {
            return await _buyingsRepository.GetAll(include: i => 
                i.Include(buying => buying.Commodity).ThenInclude(commodity => commodity.DefaultMeasure)).ToListAsync(cancellationToken);
        }
    }
}
