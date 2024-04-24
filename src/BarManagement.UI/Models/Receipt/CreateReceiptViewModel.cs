using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Receipt
{
    public class CreateReceiptViewModel
    {
        public bool IsPaid { get; set; } = false;

        [Required]
        public Guid[] CoctailIds { get; set; } = new Guid[0];

        [Required]
        public Guid[] DrinkIds { get; set; } = new Guid[0];

        [Required]
        public Guid BarmenId { get; set; }
    }
}
