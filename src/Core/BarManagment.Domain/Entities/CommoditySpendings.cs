

using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class CommoditySpendings : Entity
    {
        public CommoditySpendings(
            Guid id, 
            DateTime dateOfBuy, 
            int amount,
            Commodity commodity)
            : base(id)
        {
            DateOfBuy = dateOfBuy;
            Amount = amount;
            CommodityId = commodity.Id;
        }
        public DateTime DateOfBuy { get; private set; }
        public int Amount { get; private set; }

        //foreign
        public Guid CommodityId { get; private set; }
    }
}
