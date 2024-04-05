using BarManagment.Domain.DomainEntities;

namespace BarManagment.Application.Core.Abstractions.BuyingServices
{
    public interface IAvailabilityServiceCheck
    {
        Task<bool> CheckIfCommodityAvailable(Commodity commodity, double amountRequired);
    }
}
