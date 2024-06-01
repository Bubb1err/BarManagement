using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Drinks.Queries.GetDrinks
{
    internal class GetDrinksQueryHandler : IRequestHandler<GetDrinksQuery, IEnumerable<Drink>>
    {
        private readonly IRepository<Drink> _drinksRepository;
        private readonly IRepository<User> _usersRepository;

        public GetDrinksQueryHandler(IRepository<Drink> drinksRepository, IRepository<User> usersRepository)
        {
            _drinksRepository = drinksRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<Drink>> Handle(GetDrinksQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);
            var drinks = await _drinksRepository.GetAll(d => d.CompanyCode == user.CompanyCode, include: i => i.Include(drink => drink.Commodity)
                        .ThenInclude(commodity => commodity.DefaultMeasure)).ToListAsync();
            return drinks;
        }
    }
}
