using BarManagement.UI.Models.Measure;

namespace BarManagement.UI.Models.Commodity
{
    public class CommodityViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public Guid DefaultMeasureId { get; set; }

        public DefaultMeasureViewModel DefaultMeasure { get; set; }
    }
}
