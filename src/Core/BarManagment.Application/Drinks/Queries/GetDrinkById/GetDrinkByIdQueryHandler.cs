using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Drinks.Queries.GetDrinkById
{
    internal class GetDrinkByIdQueryHandler : IRequestHandler<GetDrinkByIdQuery, Drink>
    {
        private readonly IRepository<Drink> _drinkRepository;

        public GetDrinkByIdQueryHandler(IRepository<Drink> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<Drink> Handle(GetDrinkByIdQuery request, CancellationToken cancellationToken)
        {
            var drink = await _drinkRepository.GetFirstOrDefaultAsync(drink => drink.Id == request.Id, 
                include: i => i.Include(drink => drink.Commodity).ThenInclude(commodity => commodity.DefaultMeasure));
            return drink;
        }
    }
}
