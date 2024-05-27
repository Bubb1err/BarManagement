using BarManagment.Domain.Models.Receipts;
using MediatR;

namespace BarManagment.Application.Receipt.Queries.BarmenReceipts
{
    public sealed class GetBarmenReceiptsQuery : IRequest<IEnumerable<BarmenReceiptViewModel>>
    {
        public GetBarmenReceiptsQuery(Guid barmenId, DateTime startDate, DateTime endDate)
        {
            BarmenId = barmenId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid BarmenId { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
