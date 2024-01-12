using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Commoditys.Queries.GetAllCommodity
{
    internal class GetAllCommodityQueryHandler : IRequestHandler<GetAllCommodityQuery, IEnumerable<Commodity>>
    {
        private readonly IRepository<Commodity> _commodityRepository;

        public GetAllCommodityQueryHandler(IRepository<Commodity> commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }
        public async Task<IEnumerable<Commodity>> Handle(GetAllCommodityQuery request, CancellationToken cancellationToken)
        {
            return await _commodityRepository.GetAll(include: i => i.Include(c => c.DefaultMeasure)).ToListAsync();
        }
    }
}
