namespace BarManagment.Domain.Entities
{
    public sealed class DrinkIngredient
    {
        public int DrinkIngredientId { get; set; }
        public double AmountInMeasure { get; set; }

        //foreign
        public int CommodityId { get; set; }
        public int DrinkId { get; set; }
    }
}
