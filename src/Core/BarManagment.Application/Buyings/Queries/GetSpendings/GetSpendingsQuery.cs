using BarManagment.Domain.Models.Buyings;
using MediatR;

namespace BarManagment.Application.Buyings.Queries.GetSpendings
{
    public sealed class GetSpendingsQuery : IRequest<IEnumerable<SpendingViewModel>>
    {
        public GetSpendingsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
