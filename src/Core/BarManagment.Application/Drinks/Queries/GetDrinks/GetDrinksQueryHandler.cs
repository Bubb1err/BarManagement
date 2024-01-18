using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Drinks.Queries.GetDrinks
{
    internal class GetDrinksQueryHandler : IRequestHandler<GetDrinksQuery, IEnumerable<Drink>>
    {
        private readonly IRepository<Drink> _drinksRepository;

        public GetDrinksQueryHandler(IRepository<Drink> drinksRepository)
        {
            _drinksRepository = drinksRepository;
        }
        public async Task<IEnumerable<Drink>> Handle(GetDrinksQuery request, CancellationToken cancellationToken)
        {
            var drinks = await _drinksRepository.GetAll(include: i => i.Include(drink => drink.Commodity)
                        .ThenInclude(commodity => commodity.DefaultMeasure)).ToListAsync();
            return drinks;
        }
    }
}
