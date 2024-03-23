using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Receipt.Commands.CreateReceipt
{
    internal sealed class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, BarManagment.Domain.DomainEntities.Receipt>
    {
        private readonly IRepository<Drink> _drinksRepository;
        private readonly IRepository<Coctail> _coctailsRepository;
        private readonly IRepository<Domain.DomainEntities.Receipt> _receiptRepository;

        public CreateReceiptCommandHandler(
            IRepository<Drink> drinksRepository,
            IRepository<Coctail> coctailsRepository,
            IRepository<BarManagment.Domain.DomainEntities.Receipt> receiptRepository)
        {
            _drinksRepository = drinksRepository;
            _coctailsRepository = coctailsRepository;
            _receiptRepository = receiptRepository;
        }
        public async Task<BarManagment.Domain.DomainEntities.Receipt> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            // var drinks = 
            return null;
        }
    }
}
