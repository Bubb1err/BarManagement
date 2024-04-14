using MediatR;

namespace BarManagment.Application.Receipt.Commands.PayReceipt
{
    public sealed class PayReceiptCommand : IRequest<Domain.DomainEntities.Receipt>
    {
        public PayReceiptCommand(Guid receiptId)
        {
            ReceiptId = receiptId;
        }

        public Guid ReceiptId { get; }
    }
}
