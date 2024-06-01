using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Drinks.Queries.SearchDrinks
{
    internal sealed class SearchDrinkQueryHandler : IRequestHandler<SearchDrinkQuery, IEnumerable<Drink>>
    {
        private readonly IRepository<Drink> _drinksRepository;

        public SearchDrinkQueryHandler(IRepository<Drink> drinksRepository)
        {
            _drinksRepository = drinksRepository;
        }

        public async Task<IEnumerable<Drink>> Handle(SearchDrinkQuery request, CancellationToken cancellationToken)
        {
            var drinks = await _drinksRepository.GetAll(d => d.Name.ToLower().Contains(request.Search.ToLower())).ToListAsync();
            return drinks;
        }
    }
}
