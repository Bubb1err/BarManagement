using BarManagment.Application.Core.Abstractions.BuyingServices;
using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Receipt.Commands.CreateReceipt
{
    internal sealed class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, BarManagment.Domain.DomainEntities.Receipt>
    {
        private readonly IRepository<Drink> _drinksRepository;
        private readonly IRepository<Coctail> _coctailsRepository;
        private readonly IRepository<Domain.DomainEntities.Receipt> _receiptRepository;
        private readonly IAvailabilityServiceCheck _availabilityServiceCheck;
        private readonly IBuyingsRepository _buyingsRepository;
        private readonly IRepository<User> _userRepository;

        public CreateReceiptCommandHandler(
            IRepository<Drink> drinksRepository,
            IRepository<Coctail> coctailsRepository,
            IRepository<BarManagment.Domain.DomainEntities.Receipt> receiptRepository,
            IAvailabilityServiceCheck availabilityServiceCheck,
            IBuyingsRepository buyingsRepository,
            IRepository<User> userRepository)
        {
            _drinksRepository = drinksRepository;
            _coctailsRepository = coctailsRepository;
            _receiptRepository = receiptRepository;
            _availabilityServiceCheck = availabilityServiceCheck;
            _buyingsRepository = buyingsRepository;
            _userRepository = userRepository;
        }
        public async Task<BarManagment.Domain.DomainEntities.Receipt> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            var barmen = await _userRepository.GetFirstOrDefaultAsync(user => user.Id == request.BarmenId);
            if (barmen is null)
            {
                throw new ExecutingException($"Barmen with id {request.BarmenId} was not found.", System.Net.HttpStatusCode.BadRequest);
            }

            var drinks = await _drinksRepository.GetAll(drink => request.DrinkIds.Contains(drink.Id),
                include: i => i.Include(drink => drink.Commodity)).ToListAsync();
            if (drinks is not null)
            {
                foreach (var drink in drinks)
                {
                    bool isCommodityAvailable = await _availabilityServiceCheck.CheckIfCommodityAvailable(drink.Commodity, drink.AmountInDefaultMeasure);

                    if (!isCommodityAvailable)
                    {
                        throw new ExecutingException($"Commodity with id {drink.Commodity.Id} is not available", System.Net.HttpStatusCode.BadRequest);
                    }
                    var buying = await _buyingsRepository.GetLastBuying(drink.CommodityId);

                    if (buying is null)
                    {
                        throw new ExecutingException($"No commodity available", System.Net.HttpStatusCode.BadRequest);
                    }

                    buying.UpdateAmount(drink.AmountInDefaultMeasure);
                    _buyingsRepository.Update(buying);
                }
            }

            var coctails = await _coctailsRepository.GetAll(coctail => request.CoctailIds.Contains(coctail.Id),
                include: i => i.Include(coctail => coctail.Ingredients).ThenInclude(ingredient => ingredient.Commodity)).ToListAsync();

            foreach(var coctail in coctails)
            {
                foreach (var ingredient in coctail.Ingredients)
                {
                    bool isCommodityAvailable = await _availabilityServiceCheck.CheckIfCommodityAvailable(ingredient.Commodity, ingredient.AmountInDefaultMeasure);

                    if (!isCommodityAvailable)
                    {
                        throw new ExecutingException($"Commodity with id {ingredient.Commodity.Id} is not available", System.Net.HttpStatusCode.BadRequest);
                    }

                    var buying = await _buyingsRepository.GetLastBuying(ingredient.CommodityId);

                    if (buying is null)
                    {
                        throw new ExecutingException($"No commodity available", System.Net.HttpStatusCode.BadRequest);
                    }
                    buying.UpdateAmount(ingredient.AmountInDefaultMeasure);
                    _buyingsRepository.Update(buying);
                }
            }


            var receipt = BarManagment.Domain.DomainEntities.Receipt.Create(null, barmen, false, drinks, coctails);
            await _receiptRepository.AddAsync(receipt);
            await _receiptRepository.SaveChangesAsync();

            return receipt;
        }
    }
}
