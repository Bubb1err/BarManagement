using BarManagment.Application.Core.Abstractions.BuyingServices;
using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.DomainEntities;

namespace BarManagment.Infrastructure.ReceiptServices
{
    public class AvailabilityServiceCheck : IAvailabilityServiceCheck
    {
        private readonly IBuyingsRepository _buyingsRepository;

        public AvailabilityServiceCheck(IBuyingsRepository buyingsRepository)
        {
            _buyingsRepository = buyingsRepository;
        }

        public async Task<bool> CheckIfCommodityAvailable(Commodity commodity, double amountRequired)
        {
            var lastBuying = await _buyingsRepository.GetLastBuying(commodity.Id);

            if (lastBuying is null)
            {
                return false;
            }

            return lastBuying.AvailableAmount >= amountRequired;
        }
    }
}
