using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class CoctailIngredient : BaseEntity
    {
        private CoctailIngredient(
            Guid id, 
            Commodity commodity, 
            double amount,
            Guid coctailId)
            : base(id)
        {
            Commodity = commodity;
            CommodityId = commodity.Id;
            AmountInDefaultMeasure = amount;
            CoctailId = coctailId;
        }
        private CoctailIngredient() { }

        public Guid CoctailId { get; private set; }

        public Guid CommodityId { get; private set; }
        
        public Commodity Commodity { get; private set; }

        public double AmountInDefaultMeasure { get; private set; }

        public static CoctailIngredient Create(Commodity commodity, int amountInDefaultMeasure, Guid coctailId)
        {
            return new CoctailIngredient(Guid.NewGuid(), commodity, amountInDefaultMeasure, coctailId);
        }
    }
}
