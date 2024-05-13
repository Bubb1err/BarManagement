using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Models.Buyings;

namespace BarManagment.Domain.Abstractions.Repository
{
    public interface IBuyingsRepository : IRepository<Buying>
    {
        Task<double> GetLeftAmount(Guid commodityId);

        Task<Buying?> GetLastBuying(Guid commodityId);

        IQueryable<SpendingViewModel> GetSpendings();
    }
}
