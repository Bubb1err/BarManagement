using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.GetCoctails
{
    public class GetCoctailsQuery : IRequest<IEnumerable<Coctail>>
    {
        public GetCoctailsQuery(Guid userId, string search = null)
        {
            UserId = userId;
            Search = search;
        }

        public Guid UserId { get; }

        public string Search { get; }
    }
}
