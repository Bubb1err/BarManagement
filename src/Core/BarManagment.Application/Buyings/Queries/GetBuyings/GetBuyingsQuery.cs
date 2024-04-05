using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Buyings.Queries.GetBuyings
{
    public sealed class GetBuyingsQuery : IRequest<IEnumerable<Buying>>
    {
    }
}
