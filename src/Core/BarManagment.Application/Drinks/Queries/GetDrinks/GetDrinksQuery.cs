using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Queries.GetDrinks
{
    public class GetDrinksQuery : IRequest<IEnumerable<Drink>>
    {
        public GetDrinksQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
