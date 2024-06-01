using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.SearchCoctails
{
    public sealed class SearchCoctailsQuery : IRequest<IEnumerable<Coctail>>
    {
        public SearchCoctailsQuery(string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
