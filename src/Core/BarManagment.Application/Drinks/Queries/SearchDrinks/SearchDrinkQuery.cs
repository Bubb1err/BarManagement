using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Queries.SearchDrinks
{
    public sealed class SearchDrinkQuery : IRequest<IEnumerable<Drink>>
    {
        public SearchDrinkQuery(Guid userId, string search)
        {
            UserId = userId;
            Search = search;
        }

        public Guid UserId { get; }

        public string Search { get; }
    }
}
