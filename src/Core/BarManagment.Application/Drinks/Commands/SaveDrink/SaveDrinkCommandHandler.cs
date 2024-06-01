using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;


namespace BarManagment.Application.Drinks.Commands.SaveDrink
{
    internal class SaveDrinkCommandHandler : IRequestHandler<SaveDrinkCommand, Drink>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IRepository<Drink> _drinkRepository;
        private readonly IRepository<User> _usersRepository;

        public SaveDrinkCommandHandler(
            IRepository<Commodity> commodityRepository, 
            IRepository<Drink> drinkRepository,
            IRepository<User> usersRepository)
        {
            _commodityRepository = commodityRepository;
            _drinkRepository = drinkRepository;
            _usersRepository = usersRepository;
        }
        public async Task<Drink> Handle(SaveDrinkCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);

            var commodity = await _commodityRepository.GetFirstOrDefaultAsync(commodity => commodity.Id == request.CommodityId);
            if (commodity is null)
            {
                throw new ExecutingException($"Commodity with id {request.CommodityId} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            var drink = Drink.Create(request.Name, request.Description, request.Price, request.AmountInDefaultMeasure, commodity, user.CompanyCode);
            await _drinkRepository.AddAsync(drink);
            await _drinkRepository.SaveChangesAsync();
            return drink;
        }
    }
}
