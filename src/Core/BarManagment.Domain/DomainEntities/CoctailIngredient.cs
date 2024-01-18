using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class CoctailIngredient : BaseEntity
    {
        public CoctailIngredient(
            Guid id, 
            Guid commodityId, 
            double amount,
            Guid coctailId)
            : base(id)
        {
            CommodityId = commodityId;
            AmountInDefaultMeasure = amount;
            CoctailId = coctailId;
        }
        private CoctailIngredient() { }
        public Guid CoctailId { get; private set; }
        public Guid CommodityId { get; private set; }
        public double AmountInDefaultMeasure { get; private set; }
        public static CoctailIngredient Create(Guid commodityId, int amountInDefaultMeasure, Guid coctailId)
        {
            return new CoctailIngredient(Guid.NewGuid(), commodityId, amountInDefaultMeasure, coctailId);
        }
    }
}
