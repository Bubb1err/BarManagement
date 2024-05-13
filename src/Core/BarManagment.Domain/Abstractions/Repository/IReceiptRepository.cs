using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;

namespace BarManagment.Domain.Abstractions.Repository
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        List<Guid> GetCoctailsRating();
    }
}
