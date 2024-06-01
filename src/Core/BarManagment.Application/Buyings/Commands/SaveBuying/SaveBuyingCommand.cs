using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Buyings.Commands.SaveBuying
{
    public sealed class SaveBuyingCommand : IRequest<Buying>
    {
        public SaveBuyingCommand(
            Guid commodityId, 
            DateTime purchaseDate,
            double purchaseAmount,
            Guid userId)
        {
            CommodityId = commodityId;
            PurchaseDate = purchaseDate;
            PurchaseAmount = purchaseAmount;
            UserId = userId;
        }
        public Guid CommodityId { get; }

        public DateTime PurchaseDate { get; }

        public double PurchaseAmount { get; }

        public Guid UserId { get; }
    }
}
