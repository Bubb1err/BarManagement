using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public class Buying : BaseEntity
    {
        private Buying(
            Guid id,
            Commodity commodity,
            DateTime purchaseDate,
            double availableAmount,
            double purchaseAmount) : base(id) 
        {
            CommodityId = commodity.Id;
            Commodity = commodity;
            PurchaseDate = purchaseDate;
            AvailableAmount = availableAmount;
            PurchaseAmount = purchaseAmount;
        }

        private Buying() { }

        public Guid CommodityId { get; private set; }

        public Commodity Commodity { get; private set; }

        public DateTime PurchaseDate { get; private set; }

        public double AvailableAmount { get; private set; }

        public double PurchaseAmount { get; private set; }
    }
}
