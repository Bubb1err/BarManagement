using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Buyings
{
    public class CreateBuyingViewModel
    {
        [Required]
        public Guid CommodityId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public double PurchaseAmount { get; set; }
    }
}
