using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Receipt.Commands.PayReceipt
{
    internal sealed class PayReceiptCommandHandler : IRequestHandler<PayReceiptCommand, Domain.DomainEntities.Receipt>
    {
        private readonly IRepository<Domain.DomainEntities.Receipt> _receiptsRepository;

        public PayReceiptCommandHandler(IRepository<Domain.DomainEntities.Receipt> receiptsRepository)
        {
            _receiptsRepository = receiptsRepository;
        }

        public async Task<Domain.DomainEntities.Receipt> Handle(PayReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptsRepository.GetFirstOrDefaultAsync(r => r.Id == request.ReceiptId);

            if (receipt is null)
            {
                throw new ExecutingException($"Receipt with id {request.ReceiptId} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            receipt.Pay();
            _receiptsRepository.Update(receipt);
            await _receiptsRepository.SaveChangesAsync();

            return receipt;
        }
    }
}
