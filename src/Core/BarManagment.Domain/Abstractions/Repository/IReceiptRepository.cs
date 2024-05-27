using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Models.Receipts;

namespace BarManagment.Domain.Abstractions.Repository
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        List<Guid> GetCoctailsRating();

        IEnumerable<BarmenReceiptViewModel> GetBarmenReceipts(Guid barmenId, DateTime startDate, DateTime endDate);
    }
}
