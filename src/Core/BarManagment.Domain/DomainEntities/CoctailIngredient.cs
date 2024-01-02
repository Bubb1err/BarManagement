using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class CoctailIngredient : BaseEntity
    {
        public CoctailIngredient(
            Guid id, 
            Commodity commodity, 
            double amount)
            : base(id)
        {
            CommodityId = commodity.Id;
            AmountInDefaultMeasure = amount;
        }
        public Guid CommodityId { get; private set; }
        public double AmountInDefaultMeasure { get; private set; }
    }
}
