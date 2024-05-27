using BarManagment.Domain.Abstractions.Repository.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Receipt.Queries.GetAll
{
    internal sealed class GetAllReceiptsQueryHandler : IRequestHandler<GetAllReceiptsQuery, IEnumerable<Domain.DomainEntities.Receipt>>
    {
        private readonly IRepository<Domain.DomainEntities.Receipt> _receiptRepository;

        public GetAllReceiptsQueryHandler(
            IRepository<Domain.DomainEntities.Receipt> receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<IEnumerable<Domain.DomainEntities.Receipt>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            return await _receiptRepository.GetAll().Include(i => i.Coctails).Include(i => i.Drinks).OrderByDescending(r => !r.IsPaid).ToListAsync();
        }
    }
}
