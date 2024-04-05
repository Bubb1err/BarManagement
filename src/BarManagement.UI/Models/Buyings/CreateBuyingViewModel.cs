using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Buyings
{
    public class CreateBuyingViewModel
    {
        [Required]
        public Guid CommodityId { get; }

        [Required]
        public DateTime PurchaseDate { get; }

        [Required]
        public double PurchaseAmount { get; }
    }
}
