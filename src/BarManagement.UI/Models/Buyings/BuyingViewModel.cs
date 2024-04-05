using BarManagement.UI.Models.Commodity;

namespace BarManagement.UI.Models.Buyings
{
    public class BuyingViewModel
    {
        public Guid Id { get; set; }

        public Guid CommodityId { get; set; }

        public CommodityViewModel Commodity { get; set; }

        public DateTime PurchaseDate { get; set; }

        public double AvailableAmount { get; set; }

        public double PurchaseAmount { get; set; }
    }
}
