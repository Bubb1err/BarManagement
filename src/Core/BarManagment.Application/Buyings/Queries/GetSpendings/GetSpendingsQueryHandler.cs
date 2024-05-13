using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Models.Buyings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Buyings.Queries.GetSpendings
{
    internal sealed class GetSpendingsQueryHandler : IRequestHandler<GetSpendingsQuery, IEnumerable<SpendingViewModel>>
    {
        private readonly IBuyingsRepository _buyingsRepository;

        public GetSpendingsQueryHandler(IBuyingsRepository buyingsRepository)
        {
            _buyingsRepository = buyingsRepository;
        }

        public async Task<IEnumerable<SpendingViewModel>> Handle(GetSpendingsQuery request, CancellationToken cancellationToken)
        {
            var spendings = await _buyingsRepository.GetSpendings().ToListAsync();
            return spendings;
        }
    }
}
