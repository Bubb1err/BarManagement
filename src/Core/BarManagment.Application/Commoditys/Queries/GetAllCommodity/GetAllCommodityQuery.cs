using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Commoditys.Queries.GetAllCommodity
{
    public class GetAllCommodityQuery : IRequest<IEnumerable<Commodity>>
    {
        public GetAllCommodityQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
