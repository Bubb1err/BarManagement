using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Drink : BaseEntity
    {
        private Drink(
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
            Commodity = commodity;
            CommodityId = commodity.Id;
        }
        private Drink() { }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CommodityId { get; private set; }
        public Commodity Commodity { get; private set; }
        public double AmountInDefaultMeasure { get; private set; }
        public static Drink Create(string name, string description, decimal price,  double amount, Commodity commodity)
        {
            return new Drink(Guid.NewGuid(), name, description, price, amount, commodity);
        }
        public void Update(string name, string description, decimal price, double amount, Commodity commodity)
        {
            Name = name;
            Description = description;
            Price = price;
            AmountInDefaultMeasure = amount;
            CommodityId = commodity.Id;
        }
    }
}
