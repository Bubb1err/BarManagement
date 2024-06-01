using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Drinks
{
    public class CreateDrinkViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public Guid CommodityId { get; set; }

        [Required]
        public double AmountInDefaultMeasure { get; set; }

        public string? UserId { get; set; }
    }
}
