using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Drinks.Commands.UpdateDrink
{
    internal class UpdateDrinkCommandHandler : IRequestHandler<UpdateDrinkCommand, Drink>
    {
        private readonly IRepository<Drink> _drinkRepository;
        private readonly IRepository<Commodity> _commodityRepository;

        public UpdateDrinkCommandHandler(
            IRepository<Drink> drinkRepository,
            IRepository<Commodity> commodityRepository)
        {
            _drinkRepository = drinkRepository;
            _commodityRepository = commodityRepository;
        }
        public async Task<Drink> Handle(UpdateDrinkCommand request, CancellationToken cancellationToken)
        {
            var drink = await _drinkRepository.GetFirstOrDefaultAsync(drink => drink.Id == request.Id);
            if (drink is null) 
            {
                throw new ExecutingException($"Drink with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            var commodity = await _commodityRepository.GetFirstOrDefaultAsync(commodity => commodity.Id == request.CommodityId);
            if (commodity is null)
            {
                throw new ExecutingException($"Commodity with id {request.CommodityId} was not found.", System.Net.HttpStatusCode.NotFound);
            }
            drink.Update(request.Name, request.Description, request.Price, request.AmountInDefaultMeasure, commodity);
            _drinkRepository.Update(drink);
            await _drinkRepository.SaveChangesAsync();
            return drink;
        }
    }
}
