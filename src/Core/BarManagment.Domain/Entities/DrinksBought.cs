using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class DrinksBought : Entity
    {
        public DrinksBought(
            Guid id,
            int amount, 
            ServingDrink drink, 
            Receipt receipt)
            : base(id)
        {
             Amount = amount;
            ServingDrinkId = drink.Id;
            ReceiptId = receipt.Id;
        }
        public int Amount { get; private set; }
        //foreign 
        public Guid ServingDrinkId { get; private set; }
        public Guid ReceiptId { get; private set; }
    }
}
