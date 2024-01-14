using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.GetCoctailById
{
    public class GetCoctailByIdQuery : IRequest<Coctail>
    {
        public GetCoctailByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
