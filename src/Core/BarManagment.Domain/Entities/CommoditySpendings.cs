

namespace BarManagment.Domain.Entities
{
    public sealed class CommoditySpendings
    {
        public int CommoditySpendingId { get; set; }
        public DateTime DateOfBuy { get; set; }
        public int Amount { get; set; }


        //foreign
        public int CommodityId { get; set; }
    }
}
