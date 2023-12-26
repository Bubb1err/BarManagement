
using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class SupplySpendings : Entity
    {
        public SupplySpendings(
            Guid id, 
            DateTime dateOfBuy, 
            int amount, 
            Supply supply)
            : base(id)
        {
            DateOfBuy = dateOfBuy;
            Amount = amount;
            SupplyId = supply.Id;
        }
        public DateTime DateOfBuy { get; private set; }
        public int Amount { get; private set; }
        //foreign 
        public Guid SupplyId { get; private set; }

    }
}
