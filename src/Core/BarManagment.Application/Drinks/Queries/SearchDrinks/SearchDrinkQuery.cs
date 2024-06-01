using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Queries.SearchDrinks
{
    public sealed class SearchDrinkQuery : IRequest<IEnumerable<Drink>>
    {
        public SearchDrinkQuery(string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
