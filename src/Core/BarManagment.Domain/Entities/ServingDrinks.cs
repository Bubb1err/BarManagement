namespace BarManagment.Domain.Entities
{
    public sealed class ServingDrinks
    {
        public int DrinkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double ServeAmountMl { get; set; }
        public double Price { get; set; }
        public bool IsAlcohol { get; set; }

    }
}
