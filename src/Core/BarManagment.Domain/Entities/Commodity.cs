using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class Commodity : Entity
    {
        public Commodity(
            Guid id, 
            string commodityName, 
            double price, 
            CommodityType commodityType)
            : base(id)
        {
            CommodityName = commodityName;
            Price = price;
            CommodityTypeId = commodityType.Id;
        }
        public string CommodityName { get; private set; }
        public double Price { get; private set; }

        //foreign
        public Guid CommodityTypeId { get; private set;}
    }
}
