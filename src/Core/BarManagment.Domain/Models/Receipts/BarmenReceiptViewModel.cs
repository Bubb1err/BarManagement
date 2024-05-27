namespace BarManagment.Domain.Models.Receipts
{
    public class BarmenReceiptViewModel
    {
        public Guid Id { get; set; }

        public decimal Total { get; set; }

        public DateTime Created { get; set; }
    }
}
