using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;

namespace BarManagment.Domain.Abstractions.Repository
{
    public interface IBuyingsRepository : IRepository<Buying>
    {
        Task<double> GetLeftAmount(Guid commodityId);

        Task<Buying?> GetLastBuying(Guid commodityId);
    }
}
