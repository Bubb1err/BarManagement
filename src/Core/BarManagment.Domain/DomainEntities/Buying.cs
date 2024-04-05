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

        public static Buying Create(Guid id, Commodity commodity, DateTime purchaseDate, double availableAmount, double purchaseAmount)
        {
            return new Buying(
                id,
                commodity,
                purchaseDate,
                availableAmount,
                purchaseAmount);
        } 

        public void UpdateAmount(double usedAmount)
        {
            if (usedAmount > AvailableAmount)
            {
                throw new ArgumentOutOfRangeException("Cannot update amount. Too little available amount");
            }

            AvailableAmount -= usedAmount;
        }
    }
}
