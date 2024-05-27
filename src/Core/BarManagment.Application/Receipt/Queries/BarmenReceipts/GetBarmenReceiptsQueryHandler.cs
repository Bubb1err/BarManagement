using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Models.Receipts;
using MediatR;

namespace BarManagment.Application.Receipt.Queries.BarmenReceipts
{
    internal sealed class GetBarmenReceiptsQueryHandler : IRequestHandler<GetBarmenReceiptsQuery, IEnumerable<BarmenReceiptViewModel>>
    {
        private readonly IReceiptRepository _receiptRepository;

        public GetBarmenReceiptsQueryHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public Task<IEnumerable<BarmenReceiptViewModel>> Handle(GetBarmenReceiptsQuery request, CancellationToken cancellationToken)
        {
            var receipts = _receiptRepository.GetBarmenReceipts(request.BarmenId, request.StartDate, request.EndDate).AsEnumerable();
            return Task.FromResult(receipts);
        }
    }
}
