using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Queries.GetDrinkById
{
    public class GetDrinkByIdQuery : IRequest<Drink>
    {
        public GetDrinkByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
