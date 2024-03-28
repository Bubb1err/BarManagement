using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Drinks
{
    public class UpdateDrinkViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid CommodityId { get; set; }

        [Required]
        public double AmountInDefaultMeasure { get; set; }
    }
}
