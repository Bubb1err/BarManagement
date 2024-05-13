using BarManagment.Contracts.Coctails;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Queries.GetCoctailById
{
    public class GetCoctailByIdQuery : IRequest<GetCoctailDetailsViewModel>
    {
        public GetCoctailByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
