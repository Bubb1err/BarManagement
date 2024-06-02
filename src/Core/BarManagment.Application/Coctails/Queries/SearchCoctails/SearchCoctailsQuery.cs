using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.SearchCoctails
{
    public sealed class SearchCoctailsQuery : IRequest<IEnumerable<Coctail>>
    {
        public SearchCoctailsQuery(Guid userId, string search)
        {
            UserId = userId;
            Search = search;
        }

        public Guid UserId { get; }
        public string Search { get; }
    }
}
