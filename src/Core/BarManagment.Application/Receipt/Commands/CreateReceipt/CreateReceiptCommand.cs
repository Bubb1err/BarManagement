using MediatR;

namespace BarManagment.Application.Receipt.Commands.CreateReceipt
{
    public sealed class CreateReceiptCommand : IRequest<BarManagment.Domain.DomainEntities.Receipt>
    {
        public CreateReceiptCommand(
            bool isPaid,
            string[] coctailIds,
            string[] drinkIds)
        {
            IsPaid = isPaid;
            CoctailIds = coctailIds;
            DrinkIds = drinkIds;
        }
        public bool IsPaid { get; set; }

        public string[] CoctailIds { get; set; }

        public string[] DrinkIds { get; set; }
    }
}
