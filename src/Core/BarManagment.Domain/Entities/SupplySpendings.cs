
namespace BarManagment.Domain.Entities
{
    public sealed class SupplySpendings
    {
        public int SupplySpendingId { get; set; }
        public DateTime DateOfBuy { get; set; }
        public int Amount { get; set; }
        //foreign 
        public int SupplyId { get; set; }

    }
}
