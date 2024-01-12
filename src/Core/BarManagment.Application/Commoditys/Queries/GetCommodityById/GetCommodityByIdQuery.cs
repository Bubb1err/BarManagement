using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Commoditys.Queries.GetCommodityById
{
    public class GetCommodityByIdQuery : IRequest<Commodity>
    {
        public GetCommodityByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
