using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Buyings.Commands.SaveBuying
{
    internal sealed class SaveBuyingCommandHandler : IRequestHandler<SaveBuyingCommand, Buying>
    {
        private readonly IBuyingsRepository _buyingsRepository;
        private readonly IRepository<Commodity> _commodityRepository;

        public SaveBuyingCommandHandler(
            IBuyingsRepository buyingsRepository,
            IRepository<Commodity> commodityRepository)
        {
            _buyingsRepository = buyingsRepository;
            _commodityRepository = commodityRepository;
        }
        public async Task<Buying> Handle(SaveBuyingCommand request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetFirstOrDefaultAsync(commodity => commodity.Id == request.CommodityId);
            if (commodity is null)
            {
                throw new ExecutingException($"Commodity with id {request.CommodityId} was not found.", System.Net.HttpStatusCode.BadRequest);
            }

            double leftAmount = await _buyingsRepository.GetLeftAmount(request.CommodityId);
            var buying = Buying.Create(Guid.NewGuid(), commodity, request.PurchaseDate, leftAmount + request.PurchaseAmount, request.PurchaseAmount);
            await _buyingsRepository.AddAsync(buying);
            await _buyingsRepository.SaveChangesAsync();
            return buying;
        }
    }
}
