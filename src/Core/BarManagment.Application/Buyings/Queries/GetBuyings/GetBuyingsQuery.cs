using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Buyings.Queries.GetBuyings
{
    public sealed class GetBuyingsQuery : IRequest<IEnumerable<Buying>>
    {
        public GetBuyingsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
