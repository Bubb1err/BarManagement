using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Drink : BaseEntity
    {
        public Drink(
            Guid id,
            string name, 
            string description, 
            decimal price, 
            double amount, 
            Commodity commodity)
            : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            AmountInDefaultMeasure = amount;
            CommodityId = commodity.Id;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CommodityId { get; private set; }
        public double AmountInDefaultMeasure { get; private set; }
    }
}
