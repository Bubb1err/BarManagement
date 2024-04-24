using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace BarManagment.Application.Drinks.Queries.Search
{
    internal sealed class GetDrinkBySearchQueryHandler : IRequestHandler<GetDrinkBySearchQuery, IEnumerable<Drink>>
    {
        private readonly IRepository<Drink> _drinksRepository;

        public GetDrinkBySearchQueryHandler(
            IRepository<Drink> drinksRepository)
        {
            _drinksRepository = drinksRepository;
        }
        public async Task<IEnumerable<Drink>> Handle(GetDrinkBySearchQuery request, CancellationToken cancellationToken)
        {
            return await _drinksRepository.GetAll(drink => drink.Name.ToLower().Contains(request.Search.ToLower())).ToListAsync();
        }
    }
}
