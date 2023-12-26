using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class DrinkIngredient : Entity
    {
        public DrinkIngredient(
            Guid id, 
            double amountInMeasure, 
            Commodity commodity, 
            ServingDrink drink)
            : base(id)
        {
            AmountInMeasure = amountInMeasure;
            CommodityId = commodity.Id;
            DrinkId = drink.Id;
        }
        public double AmountInMeasure { get; private set; }

        //foreign
        public Guid CommodityId { get; private set; }
        public Guid DrinkId { get; private set; }
    }
}
