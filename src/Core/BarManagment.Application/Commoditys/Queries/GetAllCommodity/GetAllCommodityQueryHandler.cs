using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Commoditys.Queries.GetAllCommodity
{
    internal class GetAllCommodityQueryHandler : IRequestHandler<GetAllCommodityQuery, IEnumerable<Commodity>>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IRepository<User> _usersRepository;

        public GetAllCommodityQueryHandler(IRepository<Commodity> commodityRepository,
            IRepository<User> usersRepository)
        {
            _commodityRepository = commodityRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<Commodity>> Handle(GetAllCommodityQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);
            return await _commodityRepository.GetAll(c => c.CompanyCode == user.CompanyCode, include: i => i.Include(c => c.DefaultMeasure)).ToListAsync();
        }
    }
}
