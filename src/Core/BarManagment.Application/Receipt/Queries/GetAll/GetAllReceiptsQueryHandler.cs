using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Receipt.Queries.GetAll
{
    internal sealed class GetAllReceiptsQueryHandler : IRequestHandler<GetAllReceiptsQuery, IEnumerable<Domain.DomainEntities.Receipt>>
    {
        private readonly IRepository<Domain.DomainEntities.Receipt> _receiptRepository;
        private readonly IRepository<User> _usersRepository;

        public GetAllReceiptsQueryHandler(
            IRepository<Domain.DomainEntities.Receipt> receiptRepository, IRepository<User> usersRepository)
        {
            _receiptRepository = receiptRepository;
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Domain.DomainEntities.Receipt>> Handle(GetAllReceiptsQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);
            return await _receiptRepository.GetAll(r => r.CompanyCode == user.CompanyCode)
                .Include(i => i.Coctails).Include(i => i.Drinks).OrderByDescending(r => !r.IsPaid).ToListAsync();
        }
    }
}
