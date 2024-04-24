using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Queries.Search
{
    public sealed class GetDrinkBySearchQuery : IRequest<IEnumerable<Drink>>
    {
        public GetDrinkBySearchQuery(string search)
        {
            Search = search;
        }
        
        public string Search { get; }
    }
}
