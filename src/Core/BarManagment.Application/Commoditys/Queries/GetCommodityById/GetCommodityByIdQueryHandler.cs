using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Commoditys.Queries.GetCommodityById
{
    internal class GetCommodityByIdQueryHandler : IRequestHandler<GetCommodityByIdQuery, Commodity>
    {
        private readonly IRepository<Commodity> _commodityRepository;

        public GetCommodityByIdQueryHandler(IRepository<Commodity> commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }
        public async Task<Commodity> Handle(GetCommodityByIdQuery request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id, include: i => i.Include(c => c.DefaultMeasure));

            return commodity;
        }
    }
}
