namespace BarManagment.Domain.Entities
{
    public sealed class DrinksBought
    {
        public int DrinksBoughtId { get; set; }
        public int Amount { get; set; }
        //foreign 
        public int ServingDrinkId { get; set; }
        public int ReceiptId { get; set; }
    }
}
