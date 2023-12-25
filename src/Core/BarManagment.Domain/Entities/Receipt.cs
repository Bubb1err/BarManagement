namespace BarManagment.Domain.Entities
{
    public sealed class Receipt
    {
        public int ReceiptId { get; set; }

        //foreign 
        public int UserId { get; set; }
    }
}
