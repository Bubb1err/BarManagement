using MediatR;

namespace BarManagment.Application.Receipt.Commands.CreateReceipt
{
    public sealed class CreateReceiptCommand : IRequest<BarManagment.Domain.DomainEntities.Receipt>
    {
        public CreateReceiptCommand(
            bool isPaid,
            Guid[] coctailIds,
            Guid[] drinkIds,
            Guid barmenId)
        {
            IsPaid = isPaid;
            CoctailIds = coctailIds;
            DrinkIds = drinkIds;
            BarmenId = barmenId;

        }
        public bool IsPaid { get; set; }

        public Guid[] CoctailIds { get; set; }

        public Guid[] DrinkIds { get; set; }

        public Guid BarmenId { get; set; }
    }
}
