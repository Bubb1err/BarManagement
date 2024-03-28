using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Commodity
{
    public class UpdateCommodityViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [Required]
        public Guid DefaultMeasureId { get; set; }
    }
}
