using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.GetCoctails
{
    public class GetCoctailsQuery : IRequest<IEnumerable<Coctail>>
    {
    }
}
