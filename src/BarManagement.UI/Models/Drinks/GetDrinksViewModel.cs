using BarManagement.UI.Models.Commodity;

namespace BarManagement.UI.Models.Drinks
{
    public class GetDrinksViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CommodityId { get; set; }

        public CommodityViewModel Commodity { get; set; }

        public double AmountInDefaultMeasure { get; set; }
    }
}
