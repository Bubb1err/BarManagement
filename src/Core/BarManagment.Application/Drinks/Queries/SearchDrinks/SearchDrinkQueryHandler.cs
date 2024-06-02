using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Drinks.Queries.SearchDrinks
{
    internal sealed class SearchDrinkQueryHandler : IRequestHandler<SearchDrinkQuery, IEnumerable<Drink>>
    {
        private readonly IRepository<Drink> _drinksRepository;
        private readonly IRepository<User> _usersRepository;

        public SearchDrinkQueryHandler(IRepository<Drink> drinksRepository, IRepository<User> usersRepository)
        {
            _drinksRepository = drinksRepository;
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Drink>> Handle(SearchDrinkQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);
            var drinks = await _drinksRepository.GetAll(d => d.Name.ToLower().Contains(request.Search.ToLower()) && d.CompanyCode == user.CompanyCode).ToListAsync();
            return drinks;
        }
    }
}
