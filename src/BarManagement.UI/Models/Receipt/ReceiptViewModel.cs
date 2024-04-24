namespace BarManagement.UI.Models.Receipt
{
    public class ReceiptViewModel
    {
        public Guid Id { get; set; }

        public DateTime? PaidTime { get; private set; }

        public DateTime Created { get; private set; }

        public bool IsPaid { get; private set; }

        public Guid BarmenId { get; private set; }
    }
}
